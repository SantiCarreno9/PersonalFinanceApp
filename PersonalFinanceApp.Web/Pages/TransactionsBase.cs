using BaseLibrary.DTOs;
using BaseLibrary.Helper.GET;
using Microsoft.AspNetCore.Components;
using PersonalFinanceApp.Web.Components;
using PersonalFinanceApp.Web.Services.Contracts;

namespace PersonalFinanceApp.Web.Pages
{
    public class TransactionsBase : CustomBase
    {
        [Inject]
        public required ITransactionService TransactionService { get; set; }

        protected GetTransactionsRequestHelper RequestHelper { get; set; } = new();

        protected bool shouldShowDialog = false;

        protected TransactionTypes currentTransactionType = TransactionTypes.Expense;

        protected TransactionDTO? CurrentTransaction = null;

        protected TransactionsGrid? TransactionsGrid { get; set; }

        protected TransactionsTotal? transactionsTotal;

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            RequestHelper.TransactionTypeId = (int)currentTransactionType;
            await UpdateTotal();
        }

        protected async Task OnFiltersUpdated()
        {
            await TransactionsGrid?.Update();
            await UpdateTotal();
        }

        protected async Task UpdateTotal()
        {
            if (transactionsTotal != null)
            {
                await transactionsTotal.Update();
                transactionsTotal.TriggerChange();
            }
        }

        public void AddTransactionBtn_Clicked()
        {
            CurrentTransaction = null;
            shouldShowDialog = true;
        }

        protected async Task OnTabSelected(TransactionTypes transactionType)
        {
            currentTransactionType = transactionType;
            RequestHelper.TransactionTypeId = transactionType == TransactionTypes.All ? null : (int)transactionType;
            await TransactionsGrid?.Update();
            await UpdateTotal();
        }

        protected void OnTransactionAdded(TransactionDTO transactionDTO)
        {
            HideDialog();
            TransactionsGrid?.Update();
            UpdateTotal();
        }

        protected void OnTransactionUpdated(TransactionDTO transactionDTO)
        {
            HideDialog();
            TransactionsGrid?.Update(false);
            UpdateTotal();
        }

        protected async Task DisplayTransaction(long id)
        {
            CurrentTransaction = await TransactionService.GetTransaction(id);
            shouldShowDialog = true;
            StateHasChanged();
        }

        public async Task DeleteTransactions()
        {
            var wasTransactionDeleted = await TransactionsGrid?.DeleteTransactions();
            if (wasTransactionDeleted)
                await UpdateTotal();
        }

        protected void HideDialog()
        {
            shouldShowDialog = false;
            StateHasChanged();
        }
    }
}
