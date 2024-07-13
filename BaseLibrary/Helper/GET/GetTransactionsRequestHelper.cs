namespace BaseLibrary.Helper.GET
{
    public class GetTransactionsRequestHelper
    {
        public string? Type { get; set; }
        public string? SortColumn { get; set; }
        public string? SortOrder { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? Description { get; set; }
        public string? Location { get; set; }
        public decimal? MinAmount { get; set; }
        public decimal? MaxAmount { get; set; }
        public int[]? Categories { get; set; }
        public int[]? PaymentMethods { get; set; }
    }
}
