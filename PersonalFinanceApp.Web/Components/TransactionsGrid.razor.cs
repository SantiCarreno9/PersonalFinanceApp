using BaseLibrary.DTOs;
using BaseLibrary.Helper.GET;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.QuickGrid;
using PersonalFinanceApp.Web.Services.Contracts;

namespace PersonalFinanceApp.Web.Components
{
    public partial class TransactionsGrid : CustomBase
    {
        [Parameter]
        public required ITransactionService TransactionService { get; set; }
        [Parameter]
        public GetTransactionsRequestHelper RequestHelper { get; set; }
        [Parameter]
        public Action<long> OnTransactionClicked { get; set; }
        [Parameter]
        public Action OnTransactionsUpdate { get; set; }
        [Parameter]
        public Action<int> OnSelectedTransactionsChanged { get; set; }

        protected GridItemsProvider<TransactionDTO>? TransactionItemsProvider { get; set; }

        public TransactionTypes currentTransactionType = TransactionTypes.Expense;

        protected PaginationState state = new PaginationState { ItemsPerPage = 20 };

        protected QuickGrid<TransactionDTO>? TransactionGrid { get; set; }
        protected bool anyResultsFound = true;

        public HashSet<long> selectedTransactions { get; private set; } = new HashSet<long>();

        private bool _shouldRender = true;

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
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
                _shouldRender = false;
                return GridItemsProviderResult.From(
                    items: simpleTransactions.Items,
                    totalItemCount: simpleTransactions.TotalCount);
            };
        }

        protected override void OnParametersSet()
        {
            base.OnParametersSet();
            if (RequestHelper == null)
                return;
            var newTransactionType = RequestHelper.TransactionTypeId.HasValue ? (TransactionTypes)RequestHelper.TransactionTypeId : TransactionTypes.All;
            if (currentTransactionType != newTransactionType)
                _shouldRender = true;
            currentTransactionType = newTransactionType;
        }

        protected void OnTransactionSelected(long id, bool value)
        {
            if (value)
            {
                if (!selectedTransactions.Contains(id))
                    selectedTransactions.Add(id);
            }
            else
            {
                if (selectedTransactions.Contains(id))
                    selectedTransactions.Remove(id);
            }
            OnSelectedTransactionsChanged?.Invoke(selectedTransactions.Count);
        }

        public async Task<bool> DeleteTransactions()
        {
            if (selectedTransactions.Count == 0)
                return false;
            var wasTransactionDeleted = await TransactionService.DeleteTransactions(selectedTransactions);
            if (wasTransactionDeleted)
            {
                await TransactionGrid!.RefreshDataAsync();
                selectedTransactions.Clear();
            }
            return wasTransactionDeleted;
        }

        public async Task Update(bool goToFirstPage = true)
        {
            _shouldRender = true;
            await state.SetCurrentPageIndexAsync(goToFirstPage ? 0 : state.CurrentPageIndex);
        }

        public void DeselectTransactions()
        {
            selectedTransactions.Clear();
            StateHasChanged();
        }

        protected override bool ShouldRender()
        {
            return _shouldRender;
        }
    }
}
