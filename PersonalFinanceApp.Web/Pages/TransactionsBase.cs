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

        protected TransactionsGrid? transactionsGrid { get; set; }

        protected TransactionsTotal? transactionsTotal;
        protected bool showDeleteDialog = false;
        protected int selectedTransactionsCount = 0;
        protected bool isEditingExistingTransaction = false;

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            RequestHelper.TransactionTypeId = (int)currentTransactionType;
            await UpdateTotal();
        }

        protected async Task OnFiltersUpdated()
        {
            await transactionsGrid?.Update();
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
            isEditingExistingTransaction = false;
            shouldShowDialog = true;
        }

        protected async void OnTransactionClicked(long id)
        {
            isEditingExistingTransaction = true;
            await DisplayTransaction(id);
        }

        public async void DuplicateTransactionBtn_Clicked()
        {
            if (transactionsGrid == null || transactionsGrid!.selectedTransactions.Count != 1) return;
            isEditingExistingTransaction = false;
            long id = transactionsGrid.selectedTransactions.First();
            transactionsGrid.DeselectTransactions();
            CurrentTransaction = await TransactionService.GetTransaction(id);
            if (CurrentTransaction != null)
                CurrentTransaction.Id = 0;
            shouldShowDialog = true;
            StateHasChanged();

        }

        protected async Task OnTabSelected(TransactionTypes transactionType)
        {
            currentTransactionType = transactionType;
            RequestHelper.TransactionTypeId = transactionType == TransactionTypes.All ? null : (int)transactionType;
            if (transactionsGrid != null)
                await transactionsGrid.Update();
            await UpdateTotal();
        }

        protected async void OnTransactionAdded(TransactionDTO transactionDTO)
        {
            HideDialog();
            transactionsGrid?.Update(false);
            transactionsGrid?.DeselectTransactions();
            selectedTransactionsCount = 0;
            StateHasChanged();
            await UpdateTotal();
        }

        protected async void OnTransactionUpdated(TransactionDTO transactionDTO)
        {
            HideDialog();
            transactionsGrid?.Update(false);
            transactionsGrid?.DeselectTransactions();
            selectedTransactionsCount = 0;
            StateHasChanged();
            await UpdateTotal();
        }

        protected async Task DisplayTransaction(long id)
        {
            CurrentTransaction = await TransactionService.GetTransaction(id);
            shouldShowDialog = true;
            StateHasChanged();
        }

        protected async Task DeleteTransactions()
        {
            if (transactionsGrid == null) return;

            var wasTransactionDeleted = await transactionsGrid.DeleteTransactions();
            if (wasTransactionDeleted)
            {
                await UpdateTotal();
                selectedTransactionsCount = 0;
                showDeleteDialog = false;
            }
        }

        protected void HideDialog()
        {
            shouldShowDialog = false;
            StateHasChanged();
        }

        protected void OnTransactionSelected(int selectedTransactions)
        {
            this.selectedTransactionsCount = selectedTransactions;
            StateHasChanged();
        }
    }
}
