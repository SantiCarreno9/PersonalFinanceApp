using BaseLibrary.Entities;

namespace PersonalFinanceApp.Api.Repositories.Contracts
{
    public interface IMetadataRepository
    {
        #region TransactionType
        Task<IEnumerable<TransactionType>?> GetTransactionTypes();
        Task<TransactionType?> GetTransactionType(int id);
        #endregion

        #region Categories
        Task<IEnumerable<Category>?> GetCategories();        
        Task<Category?> GetCategory(int id);
        Task<IEnumerable<Category>?> GetCategoriesByTransactionType(int id);
        #endregion

        #region PaymentMethods
        Task<IEnumerable<PaymentMethod>?> GetPaymentMethods();
        Task<PaymentMethod?> GetPaymentMethod(int id);        
        #endregion
    }
}
