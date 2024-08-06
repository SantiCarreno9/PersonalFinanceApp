using BaseLibrary.DTOs;
using BaseLibrary.Helper;
using BaseLibrary.Helper.GET;
using BaseLibrary.Helper.GET.Response;

namespace PersonalFinanceApp.Web.Services.Contracts
{
    public interface ITransactionService
    {
        Task<PagedList<TransactionDTO>?> GetTransactions(GetTransactionsRequestHelper request);
        Task<IEnumerable<string>?> GetLocations();
        Task<TransactionDTO?> GetTransaction(long id);
        Task<PagedList<Summary>?> GetSummaryByProperty(GetSummaryByProperty request);
        Task<decimal?> GetTotal(TransactionsFiltersDTO request);
        Task<decimal?> GetBalance(TransactionsFiltersDTO request);
        Task<TransactionDTO?> GetBoundTransactionByProperty(GetBoundTransaction request);

        Task<TransactionDTO?> CreateTransaction(TransactionDTO transactionDTO);
        Task<TransactionDTO?> UpdateTransaction(TransactionDTO transactionDTO);        
        Task<bool> DeleteTransactions(IEnumerable<long> id);
    }
}
