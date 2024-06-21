using BaseLibrary.Entities;

namespace PersonalFinanceApp.Api.Repositories.Contracts
{
    public interface ICategoryRepository
    {
        //GET        
        Task<IEnumerable<Category>?> GetCategories();        
        Task<Category?> GetCategory(int id);
        //POST        
        Task<Category> AddCategory(Category category);
        //PUT        
        Task<Category?> UpdateCategory(int id, Category category);
        //DELETE        
        Task<Category?> DeleteCategory(int id);
    }
}
