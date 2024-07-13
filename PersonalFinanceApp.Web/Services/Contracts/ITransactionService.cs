using BaseLibrary.DTOs;
using BaseLibrary.Helper;
using BaseLibrary.Helper.GET;

namespace PersonalFinanceApp.Web.Services.Contracts
{
    public interface ITransactionService
    {
        Task<PagedList<TransactionDTO>?> GetTransactions(GetTransactionsRequestHelper request);
        Task<IEnumerable<string>?> GetLocations();
        Task<TransactionDTO?> GetTransaction(long id);
        Task<TransactionDTO?> CreateTransaction(TransactionDTO transactionDTO);
        Task<TransactionDTO?> UpdateTransaction(TransactionDTO transactionDTO);
        Task<bool> DeleteTransaction(long id);
    }
}
