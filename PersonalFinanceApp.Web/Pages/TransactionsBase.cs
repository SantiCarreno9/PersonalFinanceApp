using BaseLibrary.DTOs;
using BaseLibrary.Helper.GET;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.QuickGrid;
using PersonalFinanceApp.Web.Components;
using PersonalFinanceApp.Web.Services.Contracts;

namespace PersonalFinanceApp.Web.Pages
{
    public class TransactionsBase : CustomBase
    {
        [Inject]
        public required ITransactionService TransactionService { get; set; }

        protected GetTransactionsRequestHelper RequestHelper { get; set; } = new();

        protected GridItemsProvider<TransactionDTO>? TransactionItemsProvider { get; set; }

        protected bool shouldShowDialog = false;

        protected TransactionTypes currentTransactionType = TransactionTypes.Expense;

        protected TransactionDTO? CurrentTransaction = null;

        protected PaginationState state = new PaginationState { ItemsPerPage = 20 };

        protected QuickGrid<TransactionDTO>? TransactionGrid { get; set; }
        protected bool anyResultsFound = true;

        private HashSet<long> selectedTransactions = new HashSet<long>();

        protected TransactionsTotal? transactionsTotal;

        protected bool areAllItemsSelected = false;
        protected bool isAnyItemSelected = false;
        protected string total = "0";

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            RequestHelper.TransactionTypeId = (int)currentTransactionType;

            TransactionItemsProvider = async req =>
            {
                RequestHelper.SortColumn = req.SortByColumn?.Title;
                RequestHelper.SortOrder = (req.SortByAscending ? "asc" : "desc");                
                RequestHelper.Page = (req.StartIndex / req.Count!.Value) + 1;
                RequestHelper.PageSize = req.Count!.Value;

                var simpleTransactions = await TransactionService.GetTransactions(RequestHelper);
                if ((simpleTransactions?.TotalCount != 0) != anyResultsFound)
                {
                    anyResultsFound = !anyResultsFound;
                    StateHasChanged();
                }
                selectedTransactions.Clear();
                areAllItemsSelected = false;
                isAnyItemSelected = false;

                return GridItemsProviderResult.From(
                    items: simpleTransactions!.Items,
                    totalItemCount: simpleTransactions.TotalCount);
            };
            await UpdateTotal();
        }

        protected override void OnAfterRender(bool firstRender)
        {
            base.OnAfterRender(firstRender);
        }

        protected async Task OnFiltersUpdated()
        {
            await state.SetCurrentPageIndexAsync(0);
            await TransactionGrid?.RefreshDataAsync();
            await UpdateTotal();
            await state.SetCurrentPageIndexAsync(0);
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
            RequestHelper.TransactionTypeId = transactionType == TransactionTypes.All ? null : (int)currentTransactionType;
            await TransactionGrid?.RefreshDataAsync();
            await UpdateTotal();
        }

        protected void OnTransactionAdded(TransactionDTO transactionDTO)
        {
            HideDialog();
            TransactionGrid?.RefreshDataAsync();
            UpdateTotal();
        }

        protected async Task DisplayTransaction(long id)
        {
            CurrentTransaction = await TransactionService.GetTransaction(id);
            shouldShowDialog = true;
        }

        protected void OnTransactionSelected(long id, bool value)
        {
            if (value) selectedTransactions.Add(id);
            else selectedTransactions.Remove(id);

            isAnyItemSelected = selectedTransactions.Any();
        }

        public async Task DeleteTransactions()
        {
            var wasTransactionDeleted = await TransactionService.DeleteTransactions(selectedTransactions);
            if (wasTransactionDeleted)
            {
                await TransactionGrid!.RefreshDataAsync();
                await UpdateTotal();
                selectedTransactions.Clear();
            }
        }

        protected void HideDialog()
        {
            shouldShowDialog = false;
            StateHasChanged();
        }
    }
}
