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

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            RequestHelper.Type = Enum.GetName(currentTransactionType);
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
                return GridItemsProviderResult.From(
                    items: simpleTransactions!.Items,
                    totalItemCount: simpleTransactions.TotalCount);
            };
        }

        public void AddTransactionBtn_Clicked()
        {
            CurrentTransaction = null;
            shouldShowDialog = true;
        }

        protected async Task OnTabSelected(TransactionTypes transactionType)
        {
            currentTransactionType = transactionType;
            RequestHelper.Type = Enum.GetName(currentTransactionType);
            await TransactionGrid?.RefreshDataAsync();
        }

        protected void OnTransactionAdded(TransactionDTO transactionDTO)
        {
            HideDialog();
            TransactionGrid?.RefreshDataAsync();
        }

        protected async Task DisplayTransaction(long id)
        {
            CurrentTransaction = await TransactionService.GetTransaction(id);
            shouldShowDialog = true;
        }

        public async Task DeleteTransaction(long id)
        {
            var wasTransactionDeleted = await TransactionService.DeleteTransaction(id);
            if (wasTransactionDeleted)
                await TransactionGrid.RefreshDataAsync();
        }

        protected void HideDialog()
        {
            shouldShowDialog = false;
            StateHasChanged();
        }
    }
}
