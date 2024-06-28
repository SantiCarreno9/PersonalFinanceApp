namespace BaseLibrary.DTOs
{
    public class TransactionDetailDTO
    {
        public int CategoryId { get; set; }
        public string? Description { get; set; }
        public decimal Amount { get; set; }
    }
}
