using BaseLibrary.Entities;
using BaseLibrary.Helper.GET;
using BaseLibrary.Helper.GET.Response;
using Microsoft.AspNetCore.Components;
using PersonalFinanceApp.Web.Models;
using PersonalFinanceApp.Web.Services.Contracts;
using Syncfusion.Blazor;
using Syncfusion.Blazor.DropDowns;

namespace PersonalFinanceApp.Web.Components
{
    public partial class MonthlyStats : ComponentBase
    {
        [Parameter]
        public DateRange Dates { get; set; }
        [Parameter]
        public required ITransactionService TransactionService { get; set; }
        [Parameter]
        public required Dictionary<byte, Category> Categories { get; set; }

        private int numberOfMonths = 5;
        private Theme theme = Theme.Bootstrap5Dark;

        private IEnumerable<Category>? expenseCategories { get; set; }
        private IEnumerable<Category>? incomeCategories { get; set; }

        private SfMultiSelect<int[], Category>? expenseCategoriesSelect { get; set; }
        private SfMultiSelect<int[], Category>? incomeCategoriesSelect { get; set; }

        private MonthlyTotalResponse? monthlyExpenses;
        private MonthlyTotalResponse? monthlyIncome;

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            expenseCategories = Categories.Values
                    .Where(c => (c.TransactionTypeId != null && c.TransactionTypeId.Value == (byte)TransactionTypes.Expense));
            incomeCategories = Categories.Values
                    .Where(c => (c.TransactionTypeId != null && c.TransactionTypeId.Value == (byte)TransactionTypes.Income));
        }

        public async Task UpdateData(DateRange? dateRange = null)
        {
            if (dateRange != null)
                Dates = dateRange;
            monthlyExpenses = await TransactionService.GetTotalAmountMonthly(new TransactionsFiltersDTO
            {
                TransactionTypeId = (int)TransactionTypes.Expense,
                EndDate = Dates.EndDate,
                CategoriesIds = expenseCategoriesSelect?.Value
            }, numberOfMonths);
            //if (monthlyExpenses != null)
            //    monthlyExpenses.Totals = monthlyExpenses.Totals.SkipLast(1);
            monthlyIncome = await TransactionService.GetTotalAmountMonthly(new TransactionsFiltersDTO
            {
                TransactionTypeId = (int)TransactionTypes.Income,
                EndDate = Dates.EndDate,
                CategoriesIds = incomeCategoriesSelect?.Value
            }, numberOfMonths);
            //if (monthlyIncome != null)
            //    monthlyIncome.Totals = monthlyIncome.Totals.SkipLast(1);
        }

        private async Task Reset()
        {
            if (expenseCategoriesSelect != null)
                await expenseCategoriesSelect.SelectAllAsync(false);
            if (incomeCategoriesSelect != null)
                await incomeCategoriesSelect.SelectAllAsync(false);
            await UpdateData();
        }
    }
}
