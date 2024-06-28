using BaseLibrary.Entities;
using Microsoft.EntityFrameworkCore;
using PersonalFinanceApp.Api.Data;
using PersonalFinanceApp.Api.Repositories.Contracts;

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

        public async Task<IEnumerable<Transaction>?> GetTransactions(string userId)
        {
            var transactions = await _context.Transactions
                .AsNoTracking()
                .Where(t => t.UserId == userId)
                .ToListAsync();
            return transactions;
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
    }
}
