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

        public async Task<Transaction?> GetTransaction(long id)
        {
            var transaction = await _context.Transactions
                .Include(x => x.Category)
                .AsNoTracking()
                .SingleOrDefaultAsync(t => t.Id == id);
            return transaction;
        }

        public async Task<IEnumerable<Transaction>?> GetTransactions()
        {
            var transactions = await _context.Transactions
                .Include(x => x.Category)
                .AsNoTracking()
                .ToListAsync();
            return transactions;
        }

        public async Task<Transaction?> AddTransaction(Transaction transaction)
        {
            var result = await _context.Transactions.AddAsync(transaction);
            await _context.SaveChangesAsync();
            result.Entity.Category = await GetCategory(result.Entity.CategoryId); ;
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
            var transactionToUpdate = await _context.Transactions.FindAsync(id);
            if (transactionToUpdate == null)
                return null;

            transactionToUpdate.Description = transaction.Description;
            transactionToUpdate.Date = transaction.Date;
            transactionToUpdate.CategoryId = transaction.CategoryId;
            transactionToUpdate.Amount = transaction.Amount;
            transactionToUpdate.Location = transaction.Location;

            await _context.SaveChangesAsync();
            transactionToUpdate.Category = await GetCategory(transaction.CategoryId);
            return transactionToUpdate;
        }

        private async Task<Category?> GetCategory(int id)
        {
            return await _context.Categories
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
