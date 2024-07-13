using BaseLibrary.Entities;
using BaseLibrary.Helper.GET;
using Microsoft.AspNetCore.Components;
using Syncfusion.Blazor.DropDowns;

namespace PersonalFinanceApp.Web.Components
{
    public partial class TransactionsFilters : ComponentBase
    {
        [Parameter]
        public required GetTransactionsRequestHelper RequestHelper { get; set; }
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

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
        }

        protected override async Task OnParametersSetAsync()
        {
            await base.OnParametersSetAsync();
            categoriesByTransactionType = Categories.Values
                .Where(c => (c.TransactionTypeId != null && c.TransactionTypeId.Value == (byte)Type))
                .ToList();
        }
        private async Task Reset()
        {
            RequestHelper.StartDate = null;
            RequestHelper.EndDate = null;
            RequestHelper.Description = null;
            RequestHelper.Location = null;
            RequestHelper.MinAmount = null;
            RequestHelper.MaxAmount = null;
            RequestHelper.Categories = null;
            RequestHelper.PaymentMethods = null;

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
                RequestHelper.Categories = categoriesSelect.Value;
            else RequestHelper.Categories = null;

            if (paymentMethodsSelect != null && paymentMethodsSelect.Value != null &&
                paymentMethodsSelect.Value.Length != PaymentMethods?.Count())
                RequestHelper.PaymentMethods = paymentMethodsSelect.Value;
            else RequestHelper.PaymentMethods = null;

            OnSearch?.Invoke();
        }
    }
}
