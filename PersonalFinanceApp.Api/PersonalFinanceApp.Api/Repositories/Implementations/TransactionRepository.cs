using Azure.Core;
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

        #region GET

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

        private IQueryable<Transaction> FilterTransactions(string userId, TransactionsFiltersDTO filters)
        {
            IQueryable<Transaction> transactionsQuery = _context.Transactions
                .AsNoTracking()
                .Where(t => t.UserId == userId);

            if (filters.TransactionTypeId != null)
                transactionsQuery = transactionsQuery.Where(t => t.TransactionTypeId == filters.TransactionTypeId);

            if (filters.StartDate.HasValue)
                transactionsQuery = transactionsQuery.Where(t => t.Date.CompareTo(filters.StartDate.Value) >= 0);

            if (filters.EndDate.HasValue)
                transactionsQuery = transactionsQuery.Where(t => t.Date.CompareTo(filters.EndDate.Value) <= 0);

            if (filters.MinAmount != null)
                transactionsQuery = transactionsQuery.Where(t => t.TotalAmount >= filters.MinAmount);

            if (filters.MaxAmount != null)
                transactionsQuery = transactionsQuery.Where(t => t.TotalAmount <= filters.MaxAmount);

            if (!string.IsNullOrWhiteSpace(filters.Location))
                transactionsQuery = transactionsQuery.Where(t => t.Location.Contains(filters.Location));

            if (filters.PaymentMethodsIds != null)
                transactionsQuery = transactionsQuery.Where(t => filters.PaymentMethodsIds.Contains(t.PaymentMethodId));

            if (filters.CategoriesIds != null)
            {
                transactionsQuery = transactionsQuery
                    .AsNoTracking()
                    .Include(t => t.TransactionDetails);
                transactionsQuery = transactionsQuery.Where(t => filters.CategoriesIds.Contains(t.CategoryId)
                || (t.CategoryId == 0/*Multiple*/&& t.TransactionDetails.FirstOrDefault(td => filters.CategoriesIds.Contains(td.CategoryId)) != null));
            }

            if (!string.IsNullOrWhiteSpace(filters.Description))
            {
                transactionsQuery = transactionsQuery
                    .AsNoTracking()
                    .Include(t => t.TransactionDetails);
                transactionsQuery = transactionsQuery.Where(t => t.TransactionDetails.FirstOrDefault(td => td.Description != null &&
                                    td.Description.Contains(filters.Description)) != null);
            }

            return transactionsQuery;
        }

        public async Task<PagedList<Transaction>?> GetTransactions(string userId, GetTransactionsRequestHelper request)
        {
            var transactionsQuery = FilterTransactions(userId, request);

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
                    t.TransactionTypeId,
                    t.Date,
                    t.Location,
                    t.TotalAmount,
                    t.CategoryId,
                    t.PaymentMethodId
                ));

            return await PagedList<Transaction>.CreateAsync(transactionsQuery, request.Page, request.PageSize);
        }

        public async Task<IEnumerable<TransactionType>> GetTransactionTypes()
        {
            return await _context.TransactionTypes.ToListAsync();
        }

        public async Task<decimal?> GetTotalAmount(string userId, TransactionsFiltersDTO request)
        {
            var transactionsQuery = FilterTransactions(userId, request);
            decimal total = 0;
            if (request.CategoriesIds != null)
            {
                total = await transactionsQuery
                    .SelectMany(t => t.TransactionDetails)
                    .SumAsync(td => td.Amount);
            }
            else
            {
                total = await transactionsQuery
                    .SumAsync(t => t.TotalAmount);
            }
            return total;
        }

        public async Task<decimal?> GetBalance(string userId, TransactionsFiltersDTO request)
        {
            request.TransactionTypeId = (int)TransactionTypes.Expense;
            var expense = await GetTotalAmount(userId, request);
            request.TransactionTypeId = (int)TransactionTypes.Income;
            var income = await GetTotalAmount(userId, request);


            decimal balance = 0;
            balance += income ?? 0;
            balance -= expense ?? 0;
            return balance;
        }

        public async Task<PagedList<Summary>?> GetSummaryByProperty(string userId, GetSummaryByProperty request)
        {
            IQueryable<Transaction> transactionsQuery = _context.Transactions
                .AsNoTracking()
                .Where(t => t.TransactionTypeId == request.TransactionTypeId && t.UserId.Equals(userId));

            transactionsQuery = transactionsQuery.
                Where(t => t.Date.CompareTo(request.StartDate) >= 0 && t.Date.CompareTo(request.EndDate) <= 0);

            HashSet<Summary> summaries = new HashSet<Summary>();
            switch (request.Property.ToLower())
            {
                case "paymentmethods":
                case "paymentmethod":
                    var paymentMethods = transactionsQuery
                        .Include(t => t.PaymentMethod)
                        .AsNoTracking()
                        .GroupBy(t => t.PaymentMethodId);
                    foreach (var group in paymentMethods)
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
                case "location":
                case "locations":
                    var locations = transactionsQuery
                        .AsNoTracking()
                        .GroupBy(t => t.Location);

                    foreach (var group in locations)
                    {
                        var total = group.Sum(t => t.TotalAmount);
                        if (total == 0)
                            continue;
                        summaries.Add(new Summary
                        {
                            Name = group.First().Location,
                            TotalAmount = total
                        });
                    }
                    break;
                default:
                    transactionsQuery = transactionsQuery
                        .AsNoTracking()
                        .Include(t => t.TransactionDetails)
                        .ThenInclude(td => td.Category);
                    var categories = transactionsQuery.SelectMany(td => td.TransactionDetails)
                        .GroupBy(td => td.CategoryId);
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
            }

            var summariesQueryable = summaries.AsQueryable();
            Expression<Func<Summary, object>> keySelector = request.SortProperty?.ToLower() switch
            {
                "name" => t => t.Name!,
                _ => t => t.TotalAmount,
            };

            if (request.SortOrder != null && request.SortOrder.ToLower().Equals("asc"))
                summariesQueryable = summariesQueryable.OrderBy(keySelector);
            else summariesQueryable = summariesQueryable.OrderByDescending(keySelector);

            return PagedList<Summary>.Create(summariesQueryable, request.Page, request.PageSize);
        }

        public async Task<Transaction?> GetBoundTransaction(string userId, GetBoundTransaction request)
        {
            IQueryable<Transaction> transactionsQuery = _context.Transactions
                .AsNoTracking()
                .Where(t => t.UserId == userId);

            switch (request.Property.ToLower())
            {
                case "amount":
                    transactionsQuery = transactionsQuery.OrderByDescending(t => t.TotalAmount);
                    break;
                case "category":
                    if (request.Id == null)
                        return null;
                    transactionsQuery = transactionsQuery
                        .Where(t => t.CategoryId == request.Id)
                        .OrderByDescending(t => t.TotalAmount);
                    break;
                case "paymentmethod":
                    if (request.Id == null)
                        return null;
                    transactionsQuery = transactionsQuery
                        .Where(t => t.PaymentMethodId == request.Id)
                        .OrderByDescending(t => t.TotalAmount);
                    break;
                case "location":
                    if (request.Value == null)
                        return null;
                    transactionsQuery = transactionsQuery
                        .Where(t => t.Location.ToLower().Equals(request.Value.ToLower()))
                        .OrderByDescending(t => t.TotalAmount);
                    break;
                default:
                    transactionsQuery = transactionsQuery.OrderBy(t => t.Date);
                    break;
            }
            switch (request.Position.ToLower())
            {
                case "last":
                    return await transactionsQuery.LastOrDefaultAsync();
                default:
                    return await transactionsQuery.FirstOrDefaultAsync();
            }
        }

        #endregion

        #region POST

        public async Task<Transaction?> AddTransaction(Transaction transaction)
        {
            var result = await _context.Transactions.AddAsync(transaction);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        #endregion

        #region DELETE

        public async Task<bool> DeleteTransactions(string userId, long[] ids)
        {
            int numberOfRows = 0;
            for (int i = 0; i < ids.Length; i++)
                numberOfRows += await _context.Transactions.Where(t => t.UserId.Equals(userId) && t.Id == ids[i]).ExecuteDeleteAsync();

            return numberOfRows > 0;
        }

        #endregion

        #region PUT

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
            transactionToUpdate.CategoryId = transaction.CategoryId;

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

        #endregion

        public async Task<bool> UserOwnsTransaction(string userId, long transactionId)
        {
            var transaction = await _context.Transactions.AsNoTracking().FirstOrDefaultAsync(t => t.Id == transactionId);
            if (transaction == null)
                return false;
            if (transaction.UserId.Equals(userId, StringComparison.Ordinal))
                return true;
            return false;
        }
    }
}
