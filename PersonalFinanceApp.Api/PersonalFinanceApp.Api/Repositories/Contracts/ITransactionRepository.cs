using BaseLibrary.Entities;
using BaseLibrary.Helper;
using BaseLibrary.Helper.GET;

namespace PersonalFinanceApp.Api.Repositories.Contracts
{
    public interface ITransactionRepository
    {
        //GET
        Task<PagedList<Transaction>?> GetTransactions(string userId, GetTransactionsRequestHelper request);
        Task<Transaction?> GetTransaction(string userId, long id);
        Task<Transaction?> GetBoundTransaction(string userId, GetBoundTransaction request);
        Task<IEnumerable<string>?> GetLocations(string userId);
        Task<IEnumerable<TransactionType>> GetTransactionTypes();
        Task<decimal?> GetTotalAmount(string userId, TransactionsFiltersDTO request);
        Task<decimal?> GetBalance(string userId, TransactionsFiltersDTO request);
        Task<PagedList<Summary>?> GetSummaryByProperty(string userId, GetSummaryByProperty request);        
        //POST
        Task<Transaction?> AddTransaction(Transaction transaction);
        //PUT
        Task<Transaction?> UpdateTransaction(long id, Transaction transaction);
        //DELETE
        Task<bool> DeleteTransactions(string userId, long[] ids);
        Task<bool> UserOwnsTransaction(string userId, long transactionId);        
    }
}
