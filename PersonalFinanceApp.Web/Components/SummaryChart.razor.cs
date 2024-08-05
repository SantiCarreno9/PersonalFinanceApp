using BaseLibrary.Helper;
using BaseLibrary.Helper.GET;
using Microsoft.AspNetCore.Components;
using PersonalFinanceApp.Web.Models;
using PersonalFinanceApp.Web.Services.Contracts;
using Syncfusion.Blazor;
using Syncfusion.Blazor.Charts;

namespace PersonalFinanceApp.Web.Components
{
    public partial class SummaryChart : ComponentBase
    {
        [Parameter]
        public DateRange Dates { get; set; }
        [Parameter]
        public required ITransactionService TransactionService { get; set; }

        private Theme Theme = Theme.Bootstrap5Dark;

        private PagedList<Summary>? propertySummary;

        private string propertyTitle = "Categories";
        private string property = "Categories";
        private string sortOrder = "desc";
        private string sortProperty = "amount";
        private int page = 1;
        private int pageSize = 10;
        private TransactionTypes transactionType = TransactionTypes.Expense;
        private decimal amountToSubtract = 0;
        private decimal totalAmount = 0;

        protected override void OnAfterRender(bool firstRender)
        {
            base.OnAfterRender(firstRender);
        }

        public async Task UpdateData(DateRange? dateRange = null)
        {
            if (dateRange != null)
                Dates = dateRange;
            propertySummary = await TransactionService.GetSummaryByProperty(new GetSummaryByProperty
            {
                StartDate = Dates.StartDate,
                EndDate = Dates.EndDate,
                Property = property,
                TransactionTypeId = (int)transactionType,
                Page = page,
                PageSize = pageSize,
                SortOrder = sortOrder,
                SortProperty = sortProperty
            });
            if (propertySummary != null)
            {
                totalAmount = propertySummary.Items.Sum(x => x.TotalAmount);
                //StateHasChanged();
            }
            amountToSubtract = 0;

            page = propertySummary.Page;
            pageSize = propertySummary.PageSize;
        }

        private async Task ChangeTransactionType(TransactionTypes transactionType)
        {
            this.transactionType = transactionType;
            page = 1;
            pageSize = 10;
            await UpdateData();
        }

        private async Task ChangeProperty(string property)
        {
            this.property = property;
            page = 1;
            pageSize = 10;

            propertyTitle = property switch
            {
                "PaymentMethods" => "Payment Methods",
                _ => property
            };
            await UpdateData();
        }

        private async Task NextPage()
        {
            if (propertySummary == null)
                return;

            if (propertySummary.HasNextPage)
                page++;

            await UpdateData();
        }

        private async Task PreviousPage()
        {
            if (propertySummary == null)
                return;

            if (propertySummary.HasPreviousPage)
                page--;

            await UpdateData();
        }

        private async Task GoToPage(int page)
        {
            if (propertySummary == null)
                return;

            if (page > 0 && page <= propertySummary.TotalNumberOfPages)
                this.page = page;

            await UpdateData();
        }

        private void OnLegendClicked(AccumulationLegendClickEventArgs eventArgs)
        {
            if (eventArgs.Point.Visible)
                amountToSubtract += (decimal)eventArgs.Point.Y.Value;
            else amountToSubtract -= (decimal)eventArgs.Point.Y.Value;
        }
    }
}
