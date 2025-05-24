using BaseLibrary.Entities;
using Microsoft.EntityFrameworkCore;
using PersonalFinanceApp.Api.Data;
using PersonalFinanceApp.Api.Repositories.Contracts;

namespace PersonalFinanceApp.Api.Repositories.Implementations
{
    public class MetadataRepository : IMetadataRepository
    {
        private readonly IAppDbContext _context;
        public MetadataRepository(IAppDbContext context) 
        { 
            _context = context;
        }

        #region CATEGORIES

        public async Task<Category> AddCategory(Category category)
        {
            var result = await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Category?> DeleteCategory(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null)
                return null;

            var result = _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<IEnumerable<Category>?> GetCategories()
        {            
            return await _context.Categories.ToListAsync();
        }

        public async Task<IEnumerable<Category>?> GetCategoriesByTransactionType(int id)
        {
            return await _context.Categories.Where(c=>c.TransactionTypeId == id).ToListAsync();
        }

        public async Task<Category?> GetCategory(int id)
        {            
            return await _context.Categories.SingleOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Category?> UpdateCategory(int id, PaymentMethod category)
        {
            var categoryToUpdate = await _context.Categories.FindAsync(id);
            if (categoryToUpdate == null)
                return null;

            categoryToUpdate.Name = category.Name;
            await _context.SaveChangesAsync();
            return categoryToUpdate;
        }

        #endregion

        #region PAYMENT METHODS

        public async Task<PaymentMethod?> GetPaymentMethod(int id)
        {
            return await _context.PaymentMethods.SingleOrDefaultAsync(pm => pm.Id == id);
        }

        public async Task<IEnumerable<PaymentMethod>?> GetPaymentMethods()
        {
            return await _context.PaymentMethods.ToListAsync();
        }

        #endregion

        #region TRANSACTION TYPES

        public async Task<TransactionType?> GetTransactionType(int id)
        {
            return await _context.TransactionTypes.SingleOrDefaultAsync(tt=>tt.Id == id);
        }

        public async Task<IEnumerable<TransactionType>?> GetTransactionTypes()
        {
            return await _context.TransactionTypes.ToListAsync();
        }

        #endregion
    }
}
