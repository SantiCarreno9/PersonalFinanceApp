using BaseLibrary.DTOs;

namespace PersonalFinanceApp.Web.Services.Contracts
{
    public interface ITransactionService
    {
        Task<IEnumerable<TransactionDTO>?> GetTransactions();
        Task<TransactionDTO?> GetTransaction(long id);
    }
}
