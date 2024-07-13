using BaseLibrary.DTOs;
using BaseLibrary.Entities;

namespace PersonalFinanceApp.Web.Services.Contracts
{
    public interface IMetadataService
    {
        #region TRANSACTION TYPES
        Task<IEnumerable<TransactionType>?> GetTransactionTypes();
        Task<TransactionType?> GetTransactionType(int id);
        #endregion

        #region CATEGORIES
        Task<IEnumerable<Category>?> GetCategories();
        Task<Category?> GetCategory(int id);
        #endregion

        #region PAYMENT METHODS
        Task<IEnumerable<PaymentMethod>?> GetPaymentMethods();
        Task<PaymentMethod?> GetPaymentMethod(int id);
        #endregion
    }
}
