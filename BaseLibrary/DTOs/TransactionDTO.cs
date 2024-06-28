using System.ComponentModel.DataAnnotations;

namespace BaseLibrary.DTOs
{
    public class TransactionDTO
    {
        public long Id { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; } = DateTime.Now;
        [Required]
        public decimal TotalAmount { get; set; }
        public int CategoryId { get; set; }
        public string? Location { get; set; }

        public int TransactionTypeId { get; set; }
        public int PaymentMethodId { get; set; }

        public ICollection<TransactionDetailDTO> TransactionDetails { get; set; }
    }
}
