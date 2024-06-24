using BaseLibrary.DTOs;
using Microsoft.AspNetCore.Components;
using PersonalFinanceApp.Web.Services.Contracts;
using Syncfusion.Blazor.Navigations;
using BaseLibrary.Entities;

namespace PersonalFinanceApp.Web.Pages
{
    public partial class Transactions : ComponentBase
    {
        [Inject]
        public required ITransactionService TransactionService { get; set; }
        private IQueryable<TransactionDTO>? transactions;
        private IQueryable<TransactionDTO>? visibleTransactions;
        private bool shouldShowDialog = false;

        protected override async Task OnInitializedAsync()
        {
            var simpleTransactions = await TransactionService.GetTransactions();
            transactions = simpleTransactions?.AsQueryable();

            visibleTransactions = transactions?.Where(t => t.TransactionType == TransactionType.Expense);
            //expenses = transactions?.Where(t => t.TransactionType == TransactionType.Expense);
            //income = transactions?.Where(t => t.TransactionType == TransactionType.Income);
        }

        private void OnTabSelected(SelectEventArgs eventArgs)
        {
            switch (eventArgs.SelectedIndex)
            {
                case 0:
                    visibleTransactions = transactions?.Where(t => t.TransactionType == TransactionType.Expense);
                    break;
                case 1:
                    visibleTransactions = transactions?.Where(t => t.TransactionType == TransactionType.Income);
                    break;
                default:
                    break;
            }
            StateHasChanged();
        }

        private void OnTransactionAdded(TransactionDTO transactionDTO)
        {
            transactions?.Append(transactionDTO);
            HideDialog();
        }

        private void HideDialog()
        {
            shouldShowDialog = false;
        }
    }
}
