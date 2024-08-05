namespace BaseLibrary.Helper.GET
{
    public class TransactionsFiltersDTO
    {
        public int? TransactionTypeId { get; set; }        
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? Description { get; set; }
        public string? Location { get; set; }
        public decimal? MinAmount { get; set; }
        public decimal? MaxAmount { get; set; }
        public int[]? CategoriesIds { get; set; }
        public int[]? PaymentMethodsIds { get; set; }
    }
}
