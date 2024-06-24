using BaseLibrary.DTOs;
using BaseLibrary.Entities;

namespace PersonalFinanceApp.Web.Services.Contracts
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>?> GetCategories();
        Task<Category?> GetCategory(int id);       
    }
}
