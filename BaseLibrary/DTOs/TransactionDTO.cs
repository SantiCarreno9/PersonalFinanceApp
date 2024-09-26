using System.ComponentModel.DataAnnotations;

namespace BaseLibrary.DTOs
{
    public class TransactionDTO
    {
        public long Id { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; } = DateTime.Today.ToLocalTime();
        [Required]
        public decimal TotalAmount { get; set; }
        public byte CategoryId { get; set; }
        public string? Location { get; set; }

        public byte TransactionTypeId { get; set; } = 1;
        public byte PaymentMethodId { get; set; } = 1;

        public ICollection<TransactionDetailDTO> TransactionDetails { get; set; }
    }
}
