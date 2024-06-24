using BaseLibrary.Shared;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BaseLibrary.Entities
{    
    public class Transaction
    {
        [Key]
        public long Id { get; set; }        
        [DataType(DataType.Date)]
        public DateTime Date { get; set; } = DateTime.Now;
        public decimal Amount { get; set; }
        [Column(TypeName = "nvarchar(4000)")]
        public string? Description { get; set; }
        [Column(TypeName = "nvarchar(30)")]
        public string? Location { get; set; }

        ICollection<TransactionDetail> TransactionDetails { get; set; }

        public int TransactionTypeId { get; set; }
        public int PaymentMethodId { get; set; }

        public TransactionType TransactionType { get; set; }        
        public PaymentMethod PaymentMethod { get; set; }        
    }
}
