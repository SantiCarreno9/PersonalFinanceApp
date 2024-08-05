using BaseLibrary.Entities;
using BaseLibrary.Helper.GET;
using Microsoft.AspNetCore.Components;
using PersonalFinanceApp.Web.Services.Contracts;
using Syncfusion.Blazor.DropDowns;

namespace PersonalFinanceApp.Web.Components
{
    public partial class TransactionsFilter : ComponentBase
    {
        [Parameter]
        public required GetTransactionsRequestHelper RequestHelper { get; set; }
        [Parameter]
        public required ITransactionService TransactionService { get; set; }
        [Parameter]
        public required TransactionTypes Type { get; set; }
        [Parameter]
        public required Dictionary<byte, Category> Categories { get; set; }
        [Parameter]
        public required Dictionary<byte, PaymentMethod> PaymentMethods { get; set; }
        [Parameter]
        public Action? OnSearch { get; set; }

        private IEnumerable<Category>? categoriesByTransactionType { get; set; }

        private SfMultiSelect<int[], PaymentMethod>? paymentMethodsSelect { get; set; }
        private SfMultiSelect<int[], Category>? categoriesSelect { get; set; }

        private DateTime oldestTransactionDate { get; set; } = DateTime.MinValue;

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            RequestHelper.StartDate = DateTime.MinValue;
            RequestHelper.EndDate = DateTime.Today;
            var oldestTransaction = await TransactionService.GetBoundTransactionByProperty(
                new GetBoundTransaction
                {
                    Property = "Date",
                    Position = "First"
                });
            if (oldestTransaction != null)
            {
                oldestTransactionDate = oldestTransaction.Transaction.Date;
                RequestHelper.StartDate = oldestTransactionDate;
            }
            RequestHelper.EndDate = DateTime.Today;
        }

        protected override async Task OnParametersSetAsync()
        {
            await base.OnParametersSetAsync();
            if (Type != TransactionTypes.All)
                categoriesByTransactionType = Categories.Values
                    .Where(c => (c.TransactionTypeId != null && c.TransactionTypeId.Value == (byte)Type));
            else categoriesByTransactionType = Categories.Values.Where(c => c.TransactionTypeId != null);
        }
        private async Task Reset()
        {
            RequestHelper.StartDate = oldestTransactionDate;
            RequestHelper.EndDate = DateTime.Today;
            RequestHelper.Description = null;
            RequestHelper.Location = null;
            RequestHelper.MinAmount = null;
            RequestHelper.MaxAmount = null;
            RequestHelper.CategoriesIds = null;
            RequestHelper.PaymentMethodsIds = null;

            if (categoriesSelect != null)
                await categoriesSelect.SelectAllAsync(false);
            if (paymentMethodsSelect != null)
                await paymentMethodsSelect.SelectAllAsync(false);

            OnSearch?.Invoke();
        }

        private void Search()
        {
            if (categoriesSelect != null && categoriesSelect.Value != null &&
                categoriesSelect.Value.Length != categoriesByTransactionType?.Count())
                RequestHelper.CategoriesIds = categoriesSelect.Value;
            else RequestHelper.CategoriesIds = null;

            if (paymentMethodsSelect != null && paymentMethodsSelect.Value != null &&
                paymentMethodsSelect.Value.Length != PaymentMethods?.Count())
                RequestHelper.PaymentMethodsIds = paymentMethodsSelect.Value;
            else RequestHelper.PaymentMethodsIds = null;

            OnSearch?.Invoke();
        }
    }
}
