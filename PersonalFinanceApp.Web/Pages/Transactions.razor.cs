using BaseLibrary.DTOs;
using Microsoft.AspNetCore.Components;
using PersonalFinanceApp.Web.Services.Contracts;

namespace PersonalFinanceApp.Web.Pages
{
    public partial class Transactions : ComponentBase
    {
        [Inject]
        public required ITransactionService TransactionService { get; set; }
        private IEnumerable<TransactionDTO>? transactions; 

        protected override async Task OnInitializedAsync()
        {
            transactions = await TransactionService.GetTransactions();            
        }
    }
}
