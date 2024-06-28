using BaseLibrary.Entities;

namespace PersonalFinanceApp.Api.Repositories.Contracts
{
    public interface ICategoryRepository
    {
        //GET        
        Task<IEnumerable<Category>?> GetCategories();        
        Task<Category?> GetCategory(int id);
        Task<IEnumerable<Category>?> GetCategoriesByTransactionType(int id);
        
    }
}
