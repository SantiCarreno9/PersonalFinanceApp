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
        [Inject]
        public required ICategoryService CategoryService { get; set; }

        private IQueryable<TransactionDTO>? transactions;
        private IQueryable<TransactionDTO>? visibleTransactions;
        private IEnumerable<TransactionType>? transactionTypes;
        private bool shouldShowDialog = false;

        private Dictionary<int, string> categories = new Dictionary<int, string>();

        private byte currentTransactionType = 1;

        protected override async Task OnInitializedAsync()
        {
            transactionTypes = await TransactionService.GetTransactionTypes();
            if (transactionTypes == null)
                return;

            var categories = await CategoryService.GetCategories();
            if (categories == null)
                return;

            foreach (var category in categories)
            {
                this.categories.Add(category.Id, category.Name);
            }

            var simpleTransactions = await TransactionService.GetTransactions();
            transactions = simpleTransactions?.AsQueryable();
            OnTabSelected(currentTransactionType);
        }

        private void DisplayTransaction(long id)
        {

        }

        private void OnTabSelected(int selectedType)
        {
            currentTransactionType = (byte)selectedType;
            visibleTransactions = transactions?.Where(t => t.TransactionTypeId == currentTransactionType);
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
