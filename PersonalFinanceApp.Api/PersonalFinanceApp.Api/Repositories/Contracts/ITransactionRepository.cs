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
        Task<IEnumerable<string>?> GetLocations(string userId);
        //POST
        Task<Transaction?> AddTransaction(Transaction transaction);
        //PUT
        Task<Transaction?> UpdateTransaction(long id, Transaction transaction);
        //DELETE
        Task<Transaction?> DeleteTransaction(long id);
        Task<bool> UserOwnsTransaction(string userId, long transactionId);

        Task<IEnumerable<TransactionType>> GetTransactionTypes();
        Task<decimal?> GetTotalAmountByProperty(string userId, GetTotalByProperty request);
        Task<IEnumerable<Summary>?> GetSummaryByProperty(string userId, GetSummaryByProperty request);
    }
}
