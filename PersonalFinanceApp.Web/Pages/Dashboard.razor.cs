using BaseLibrary.Helper.GET;
using Microsoft.AspNetCore.Components;
using PersonalFinanceApp.Web.Components;
using PersonalFinanceApp.Web.Models;
using PersonalFinanceApp.Web.Services.Contracts;

namespace PersonalFinanceApp.Web.Pages
{
    public partial class Dashboard : ComponentBase
    {
        enum PeriodOption
        {
            AllTime,
            Monthly,
            Custom
        }

        [Inject]
        public ITransactionService TransactionService { get; set; }

        private SummaryChart? summaryChart { get; set; }

        public DateRange EditableDateRange { get; set; } = new();
        public DateRange DateRange { get; set; } = new();

        private PeriodOption periodOption = PeriodOption.AllTime;

        private DateTime oldestTransactionDate = DateTime.MinValue;
        private TransactionsTotal? expenseTotal;
        private TransactionsTotal? incomeTotal;
        private decimal balance = 0;

        protected override async Task OnInitializedAsync()
        {
            var oldestTransaction = await TransactionService.GetBoundTransactionByProperty(
                new GetBoundTransaction
                {
                    Property = "Date",
                    Position = "First"
                });
            if (oldestTransaction != null)
                oldestTransactionDate = oldestTransaction.Transaction.Date;

            await ChangePeriodOption(PeriodOption.AllTime);

            await base.OnInitializedAsync();
        }

        protected override void OnAfterRender(bool firstRender)
        {
            base.OnAfterRender(firstRender);
        }

        private async Task ChangePeriodOption(PeriodOption option)
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

        private async Task SelectMonth(ChangeEventArgs e)
        {
            if (DateTime.TryParse(e.Value.ToString(), out DateTime selectedDate))
                SetDatesByMonth(selectedDate);

            await UpdateData();
        }

        private void SetDatesByMonth(DateTime date)
        {
            DateRange.StartDate = new DateTime(date.Year, date.Month, 1);
            DateRange.EndDate = new DateTime(date.Year, date.Month, DateTime.DaysInMonth(date.Year, date.Month));
        }

        private string GetFormattedDate(DateTime date) => date.ToString("yyyy-MM-dd");

        private async Task UpdateData(DateRange? dateRange = null)
        {
            if (dateRange!=null)
            {
                DateRange.StartDate = dateRange.StartDate;
                DateRange.EndDate = dateRange.EndDate;
            }

            balance = 0;
            if (incomeTotal != null)
                balance = await incomeTotal.Update(new TransactionsFiltersDTO
                {
                    StartDate = DateRange.StartDate,
                    EndDate = DateRange.EndDate,
                    TransactionTypeId = (int)TransactionTypes.Income
                });
            if (expenseTotal != null)
                balance -= await expenseTotal.Update(new TransactionsFiltersDTO
                {
                    StartDate = DateRange.StartDate,
                    EndDate = DateRange.EndDate,
                    TransactionTypeId = (int)TransactionTypes.Expense
                });

            if (summaryChart != null)
                await summaryChart.UpdateData(DateRange);
        }

    }
}
