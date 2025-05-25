namespace BaseLibrary.Helper.GET.Response
{
    public class MonthlyTotalResponse
    {
        public int? TransactionTypeId { get; set; }
        public int[]? Categories { get; set; }
        public IEnumerable<MonthlyTotal> Totals { get; set; } = [];
    }
}
