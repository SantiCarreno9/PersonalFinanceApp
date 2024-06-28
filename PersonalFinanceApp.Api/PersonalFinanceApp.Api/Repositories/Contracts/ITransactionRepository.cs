using BaseLibrary.Entities;

namespace PersonalFinanceApp.Api.Repositories.Contracts
{
    public interface ITransactionRepository
    {
        //GET
        Task<IEnumerable<Transaction>?> GetTransactions(string userId);
        Task<Transaction?> GetTransaction(string userId, long id);        
        //POST
        Task<Transaction?> AddTransaction(Transaction transaction);
        //PUT
        Task<Transaction?> UpdateTransaction(long id, Transaction transaction);
        //DELETE
        Task<Transaction?> DeleteTransaction(long id);
        Task<bool> UserOwnsTransaction(string userId, long transactionId);

        Task<IEnumerable<TransactionType>> GetTransactionTypes();
    }
}
