namespace BaseLibrary.Helper.GET
{
    public class GetTransactionsRequestHelper : TransactionsFiltersDTO
    {        
        public string? SortColumn { get; set; }
        public string? SortOrder { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }        
    }
}
