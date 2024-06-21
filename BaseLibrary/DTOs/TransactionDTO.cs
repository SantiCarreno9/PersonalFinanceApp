using System.ComponentModel.DataAnnotations;

namespace BaseLibrary.DTOs
{
    public class TransactionDTO
    {
        public long Id { get; set; }
        public int CategoryId { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date { get; set; } = DateTime.Now;
        public decimal Amount { get; set; }
        public string? Description { get; set; }
        public string? Location { get; set; }
        public string? CategoryName { get; set; }
    }
}
