using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BaseLibrary.Entities
{
    public class Transaction
    {
        [Key]
        public long Id { get; set; }
        public int CategoryId { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date { get; set; } = DateTime.Now;
        public decimal Amount { get; set; }
        [Column(TypeName = "nvarchar(4000)")]
        public string? Description { get; set; }
        [Column(TypeName = "nvarchar(30)")]
        public string? Location { get; set; }
        public Category? Category { get; set; }
    }
}
