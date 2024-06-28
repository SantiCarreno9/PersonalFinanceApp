using BaseLibrary.Entities;
using Microsoft.EntityFrameworkCore;
using PersonalFinanceApp.Api.Data;
using PersonalFinanceApp.Api.Repositories.Contracts;

namespace PersonalFinanceApp.Api.Repositories.Implementations
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _context;
        public CategoryRepository(AppDbContext context) 
        { 
            _context = context;
        }

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
            var categories = await _context.Categories.ToListAsync();
            return categories;
        }

        public async Task<IEnumerable<Category>?> GetCategoriesByTransactionType(int id)
        {
            return await _context.Categories.Where(c=>c.TransactionTypeId == id).ToListAsync();
        }

        public async Task<Category?> GetCategory(int id)
        {
            var category = await _context.Categories.SingleOrDefaultAsync(c => c.Id == id);
            return category;
        }

        public async Task<Category?> UpdateCategory(int id, Category category)
        {
            var categoryToUpdate = await _context.Categories.FindAsync(id);
            if (categoryToUpdate == null)
                return null;

            categoryToUpdate.Name = category.Name;
            await _context.SaveChangesAsync();
            return categoryToUpdate;
        }
    }
}
