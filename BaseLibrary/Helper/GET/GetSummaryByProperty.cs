namespace BaseLibrary.Helper.GET
{
    public class GetSummaryByProperty : BaseGetCustomDataByProperty
    {
        public int TransactionTypeId { get; set; }
        public string? SortProperty { get; set; }
        public string? SortOrder { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}
