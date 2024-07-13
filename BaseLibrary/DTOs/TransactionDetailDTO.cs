using System.ComponentModel.DataAnnotations;

namespace BaseLibrary.DTOs
{
    public class TransactionDetailDTO
    {
        [Required]
        public byte CategoryId { get; set; }
        public string? Description { get; set; }
        [Required]
        public decimal Amount { get; set; }
    }
}
