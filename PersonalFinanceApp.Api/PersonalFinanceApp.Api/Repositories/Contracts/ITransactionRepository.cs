using BaseLibrary.Entities;

namespace PersonalFinanceApp.Api.Repositories.Contracts
{
    public interface ITransactionRepository
    {
        //GET
        Task<IEnumerable<Transaction>?> GetTransactions();        
        Task<Transaction?> GetTransaction(long id);        
        //POST
        Task<Transaction?> AddTransaction(Transaction transaction);        
        //PUT
        Task<Transaction?> UpdateTransaction(long id, Transaction transaction);        
        //DELETE
        Task<Transaction?> DeleteTransaction(long id);        
    }
}
