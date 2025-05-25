using BaseLibrary.Helper.GET;
using BlazorWasmAuth.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using PersonalFinanceApp.Web.Components;
using PersonalFinanceApp.Web.Models;
using PersonalFinanceApp.Web.Services.Contracts;

namespace PersonalFinanceApp.Web.Pages
{
    public class DashboardBase : CustomBase
    {
        public enum PeriodOption
        {
            AllTime,
            Monthly,
            Custom
        }

        [Inject]
        public ITransactionService TransactionService { get; set; }
        [Inject]
        public IAccountManagement AccountManagement { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        protected SummaryChart? summaryChart { get; set; }
        protected MonthlyStats? monthlyStats { get; set; }

        public DateRange EditableDateRange { get; set; } = new();
        public DateRange DateRange { get; set; } = new();

        protected PeriodOption periodOption = PeriodOption.Monthly;

        protected DateTime oldestTransactionDate = DateTime.Today.ToLocalTime();
        protected DateTime newestTransactionDate = DateTime.Today.ToLocalTime();
        protected TransactionsTotal? expenseTotal;
        protected TransactionsTotal? incomeTotal;
        protected decimal? balance;
        protected decimal? income;
        protected decimal? expense;

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();

            var isAuthenticated = await AccountManagement.CheckAuthenticatedAsync();
            if (!isAuthenticated)
            {
                NavigationManager.NavigateTo("/login");
                return;
            }

            DateRange.StartDate = DateTime.Today;
            DateRange.EndDate = DateTime.Today;
            var oldestTransaction = await TransactionService.GetBoundTransactionByProperty(
                new GetBoundTransaction
                {
                    Property = "Date",
                    Position = "First"
                });
            var newestTransaction = await TransactionService.GetBoundTransactionByProperty(
                new GetBoundTransaction
                {
                    Property = "Date",
                    Position = "Last"
                });
            if (oldestTransaction != null)
                oldestTransactionDate = oldestTransaction.Date;
            if (newestTransaction != null)
                newestTransactionDate = newestTransaction.Date;

            await ChangePeriodOption(PeriodOption.Monthly);
        }

        protected async Task ChangePeriodOption(PeriodOption option)
        {
            periodOption = option;
            switch (option)
            {
                case PeriodOption.AllTime:
                    DateRange.StartDate = oldestTransactionDate;
                    DateRange.EndDate = DateTime.Today;
                    break;
                case PeriodOption.Monthly:
                    SetDatesByMonth(DateRange.EndDate);
                    break;
                case PeriodOption.Custom:
                    EditableDateRange.StartDate = DateRange.StartDate;
                    EditableDateRange.EndDate = DateRange.EndDate.CompareTo(DateTime.Today) > 0 ? DateTime.Today : DateRange.EndDate;
                    return;
                default:
                    return;
            }
            await UpdateData();
        }

        protected async Task SelectMonth(ChangeEventArgs e)
        {
            if (e.Value == null || string.IsNullOrEmpty(e.Value.ToString()))
                return;
            if (DateTime.TryParse(e.Value.ToString(), out DateTime selectedDate))
                SetDatesByMonth(selectedDate);

            await UpdateData();
        }

        protected void SetDatesByMonth(DateTime date)
        {
            DateRange.StartDate = new DateTime(date.Year, date.Month, 1);
            DateRange.EndDate = new DateTime(date.Year, date.Month, DateTime.DaysInMonth(date.Year, date.Month));
        }

        protected string GetFormattedDate(DateTime date) => date.ToString("yyyy-MM-dd");

        protected async Task UpdateData(DateRange? dateRange = null)
        {
            if (dateRange != null)
            {
                DateRange.StartDate = dateRange.StartDate;
                DateRange.EndDate = dateRange.EndDate;
            }

            balance = 0;

            expense = await TransactionService.GetTotal(new TransactionsFiltersDTO
            {
                StartDate = DateRange.StartDate,
                EndDate = DateRange.EndDate,
                TransactionTypeId = (int)TransactionTypes.Expense
            });

            income = await TransactionService.GetTotal(new TransactionsFiltersDTO
            {
                StartDate = DateRange.StartDate,
                EndDate = DateRange.EndDate,
                TransactionTypeId = (int)TransactionTypes.Income
            });

            balance = income ?? 0;
            balance -= expense ?? 0;

            if (summaryChart != null)
                await summaryChart.UpdateData(DateRange);

            if (monthlyStats != null)
                await monthlyStats.UpdateData(DateRange);

            //StateHasChanged();
        }

    }
}
