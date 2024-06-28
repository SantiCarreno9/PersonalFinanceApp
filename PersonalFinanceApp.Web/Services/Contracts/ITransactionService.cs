using BaseLibrary.DTOs;
using BaseLibrary.Entities;

namespace PersonalFinanceApp.Web.Services.Contracts
{
    public interface ITransactionService
    {
        Task<IEnumerable<TransactionDTO>?> GetTransactions();
        Task<TransactionDTO?> GetTransaction(long id);
        Task<TransactionDTO?> CreateTransaction(TransactionDTO transactionDTO);

        Task<IEnumerable<TransactionType>?> GetTransactionTypes();
    }
}
