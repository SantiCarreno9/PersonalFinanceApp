using BaseLibrary.Entities;
using BaseLibrary.Helper;
using BaseLibrary.Helper.GET;
using Microsoft.EntityFrameworkCore;
using PersonalFinanceApp.Api.Data;
using PersonalFinanceApp.Api.Repositories.Contracts;
using System.Linq.Expressions;

namespace PersonalFinanceApp.Api.Repositories.Implementations
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly AppDbContext _context;

        public TransactionRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Transaction?> GetTransaction(string userId, long id)
        {
            var transaction = await _context.Transactions
                .Include(t => t.TransactionDetails)!
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.UserId == userId && x.Id == id);
            return transaction;
        }

        public async Task<IEnumerable<string>?> GetLocations(string userId)
        {
            var userTransaction = _context.Transactions.AsNoTracking().Where(t => t.UserId == userId);
            IEnumerable<string>? locations = null;
            if (userTransaction != null)
                locations = await userTransaction
                    .Select(t => t.Location)
                    .Distinct()
                    .ToListAsync();
            return locations;
        }

        public async Task<PagedList<Transaction>?> GetTransactions(string userId, GetTransactionsRequestHelper request)
        {
            IQueryable<Transaction> transactionsQuery = _context.Transactions
                .AsNoTracking()
                .Where(t => t.UserId == userId);

            if (request.Type != null)
            {
                if (request.Type.ToLower().Equals("expense"))
                    transactionsQuery = transactionsQuery.Where(t => t.TransactionTypeId == (int)TransactionTypes.Expense);
                else if (request.Type.ToLower().Equals("income"))
                    transactionsQuery = transactionsQuery.Where(t => t.TransactionTypeId == (int)TransactionTypes.Income);
            }


            if (request.StartDate.HasValue)
                transactionsQuery = transactionsQuery.Where(t => t.Date.CompareTo(request.StartDate.Value) >= 0);

            if (request.EndDate.HasValue)
                transactionsQuery = transactionsQuery.Where(t => t.Date.CompareTo(request.EndDate.Value) <= 0);

            if (request.MinAmount != null)
                transactionsQuery = transactionsQuery.Where(t => t.TotalAmount >= request.MinAmount);

            if (request.MaxAmount != null)
                transactionsQuery = transactionsQuery.Where(t => t.TotalAmount <= request.MaxAmount);

            if (!string.IsNullOrWhiteSpace(request.Location))
                transactionsQuery = transactionsQuery.Where(t => t.Location.Contains(request.Location));

            if (request.PaymentMethods != null)
                transactionsQuery = transactionsQuery.Where(t => request.PaymentMethods.Contains(t.PaymentMethodId));

            if (request.Categories != null)
            {
                transactionsQuery = transactionsQuery
                    .AsNoTracking()
                    .Include(t => t.TransactionDetails);
                transactionsQuery = transactionsQuery.Where(t => request.Categories.Contains(t.CategoryId)
                || (t.CategoryId == 0/*Multiple*/&& t.TransactionDetails.FirstOrDefault(td => request.Categories.Contains(td.CategoryId)) != null));
            }

            if (!string.IsNullOrWhiteSpace(request.Description))
            {
                transactionsQuery = transactionsQuery
                    .AsNoTracking()
                    .Include(t => t.TransactionDetails);
                transactionsQuery = transactionsQuery.Where(t => t.TransactionDetails.FirstOrDefault(td => td.Description != null &&
                                    td.Description.Contains(request.Description)) != null);
            }

            Expression<Func<Transaction, object>> keySelector = request.SortColumn?.ToLower() switch
            {
                "location" => t => t.Location!,
                "amount" => t => t.TotalAmount,
                "category" => t => t.CategoryId,
                "payment method" => t => t.PaymentMethodId,
                _ => t => t.Date,
            };

            if (request.SortOrder != null && request.SortOrder.ToLower().Equals("asc"))
                transactionsQuery = transactionsQuery.OrderBy(keySelector);
            else transactionsQuery = transactionsQuery.OrderByDescending(keySelector);

            transactionsQuery = transactionsQuery
                .Select(t => new Transaction
                (
                    t.Id,
                    t.Date,
                    t.Location,
                    t.TotalAmount,
                    t.CategoryId,
                    t.PaymentMethodId
                ));

            return await PagedList<Transaction>.CreateAsync(transactionsQuery, request.Page, request.PageSize);
        }

        public async Task<Transaction?> AddTransaction(Transaction transaction)
        {
            var result = await _context.Transactions.AddAsync(transaction);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        //DELETE
        public async Task<Transaction?> DeleteTransaction(long id)
        {
            var transaction = await _context.Transactions.FindAsync(id);
            if (transaction == null)
                return null;

            var result = _context.Transactions.Remove(transaction);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        //PUT
        public async Task<Transaction?> UpdateTransaction(long id, Transaction transaction)
        {
            var transactionToUpdate = await _context.Transactions
                .Include(t => t.TransactionDetails)
                .FirstOrDefaultAsync(t => t.Id == id);
            if (transactionToUpdate == null)
                return null;

            //Transaction
            transactionToUpdate.Date = transaction.Date;
            transactionToUpdate.PaymentMethodId = transaction.PaymentMethodId;
            transactionToUpdate.TransactionTypeId = transaction.TransactionTypeId;
            transactionToUpdate.TotalAmount = transaction.TotalAmount;
            transactionToUpdate.Location = transaction.Location;

            //Transaction Details
            var existingDetails = transactionToUpdate.TransactionDetails;
            var newTransactionDetails = transaction.TransactionDetails;
            int countDifference = existingDetails.Count() - newTransactionDetails.Count();
            if (countDifference < 0)
            {
                for (int i = 0; i < Math.Abs(countDifference); i++)
                {
                    var newDetail = await _context.TransactionDetails.AddAsync(new TransactionDetail() { TransactionId = id });
                    existingDetails.Add(newDetail.Entity);
                }
            }
            else if (countDifference > 0)
            {
                for (int i = 0; i < Math.Abs(countDifference); i++)
                {
                    var deletedDetail = _context.TransactionDetails.Remove(existingDetails.ElementAt(existingDetails.Count - 1));
                    existingDetails.Remove(deletedDetail.Entity);
                }
            }

            for (int i = 0; i < existingDetails.Count; i++)
            {
                existingDetails.ElementAt(i).CategoryId = newTransactionDetails.ElementAt(i).CategoryId;
                existingDetails.ElementAt(i).Description = newTransactionDetails.ElementAt(i).Description;
                existingDetails.ElementAt(i).Amount = newTransactionDetails.ElementAt(i).Amount;
            }

            await _context.SaveChangesAsync();
            return transactionToUpdate;
        }

        public async Task<bool> UserOwnsTransaction(string userId, long transactionId)
        {
            var transaction = await _context.Transactions.AsNoTracking().FirstOrDefaultAsync(t => t.Id == transactionId);
            if (transaction == null)
                return false;
            if (transaction.UserId.Equals(userId, StringComparison.Ordinal))
                return true;
            return false;
        }

        private async Task<Category?> GetCategory(int id)
        {
            return await _context.Categories
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<TransactionType>> GetTransactionTypes()
        {
            return await _context.TransactionTypes.ToListAsync();
        }

        public async Task<decimal?> GetTotalAmountByProperty(string userId, GetTotalByProperty request)
        {
            IQueryable<Transaction> transactionsQuery = _context.Transactions
                .AsNoTracking()
                .Where(t => t.UserId.Equals(userId));
            transactionsQuery = transactionsQuery.
                Where(t => t.Date.CompareTo(request.StartDate) >= 0 && t.Date.CompareTo(request.EndDate) <= 0);
            switch (request.PropertyName.ToLower())
            {
                case "transactiontype":
                    transactionsQuery = transactionsQuery.Where(t => t.TransactionTypeId == request.Id);
                    break;
                case "category":
                    transactionsQuery = transactionsQuery
                        .AsNoTracking()
                        .Include(t => t.TransactionDetails);
                    var total = await transactionsQuery.Where(t => t.CategoryId == request.Id).SumAsync(t => t.TotalAmount);
                    await transactionsQuery.Where(t => t.CategoryId == 0)
                        .Select(td => td.TransactionDetails)
                        .ForEachAsync(td =>
                        {
                            total += (td.FirstOrDefault(tdd => tdd.CategoryId == request.Id)?.Amount ?? 0);
                            Console.WriteLine(total);
                        });
                    return total;
                case "paymentmethod":
                    transactionsQuery = transactionsQuery.Where(t => t.PaymentMethodId == request.Id);
                    break;
                default:
                    return null;
            }
            return await transactionsQuery.SumAsync(t => t.TotalAmount);
        }

        public async Task<IEnumerable<Summary>?> GetSummaryByProperty(string userId, GetSummaryByProperty request)
        {
            int transactionTypeId = -1;
            if (request.TransactionType.ToLower().Equals("expense"))
                transactionTypeId = 1;
            else if (request.TransactionType.ToLower().Equals("income"))
                transactionTypeId = 2;

            if (transactionTypeId == -1)
                return null;

            IQueryable<Transaction> transactionsQuery = _context.Transactions
                .AsNoTracking()
                .Where(t => t.TransactionTypeId == transactionTypeId && t.UserId.Equals(userId));
            transactionsQuery = transactionsQuery.
                Where(t => t.Date.CompareTo(request.StartDate) >= 0 && t.Date.CompareTo(request.EndDate) <= 0);

            List<Summary> summaries = new List<Summary>();
            switch (request.PropertyName.ToLower())
            {
                case "categories":
                    transactionsQuery = transactionsQuery
                        .AsNoTracking()
                        .Include(t => t.TransactionDetails)
                        .ThenInclude(td => td.Category);
                    List<TransactionDetail> transactionDetails = new();
                    await transactionsQuery.Select(td => td.TransactionDetails)
                        .ForEachAsync(transactionDetails.AddRange);
                    var categories = transactionDetails.GroupBy(td => td.CategoryId);
                    foreach (var group in categories)
                    {
                        var total = group.Sum(t => t.Amount);
                        if (total == 0)
                            continue;
                        summaries.Add(new Summary
                        {
                            Id = group.Key,
                            Name = group.First().Category.Name,
                            TotalAmount = total
                        });
                    }
                    break;
                case "paymentmethods":
                    var groups = transactionsQuery
                        .Include(t => t.PaymentMethod)
                        .AsNoTracking()
                        .GroupBy(t => t.PaymentMethodId);
                    foreach (var group in groups)
                    {
                        var total = group.Sum(t => t.TotalAmount);
                        if (total == 0)
                            continue;
                        summaries.Add(new Summary
                        {
                            Id = group.Key,
                            Name = group.First().PaymentMethod.Name,
                            TotalAmount = total
                        });
                    }
                    break;
                default:
                    return null;
            }
            return summaries;
        }
    }
}
