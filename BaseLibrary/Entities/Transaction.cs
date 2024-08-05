using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace BaseLibrary.Entities
{
    public class Transaction
    {
        public Transaction()
        {
            
        }
        public Transaction(long id, byte transactionTypeId, DateTime date, string? location, decimal totalAmount, byte categoryId, byte paymentMethodId)
        {
            Id = id;
            TransactionTypeId = transactionTypeId;
            Date = date;
            Location = location;
            TotalAmount = totalAmount;
            CategoryId = categoryId;
            PaymentMethodId = paymentMethodId;
        }

        [Key]
        public long Id { get; set; }
        [Column(TypeName = "nvarchar(450)")]
        public string UserId { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; } = DateTime.Now;
        [DataType(DataType.Currency)]
        public decimal TotalAmount { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string Location { get; set; }
        public byte CategoryId { get; set; }

        public byte TransactionTypeId { get; set; }
        public byte PaymentMethodId { get; set; }

        public ICollection<TransactionDetail> TransactionDetails { get; set; }
        [JsonIgnore]
        public TransactionType TransactionType { get; set; }
        [ForeignKey(nameof(PaymentMethodId))]
        [JsonIgnore]
        public PaymentMethod PaymentMethod { get; set; }

        public void Update()
        {
            if (TransactionDetails != null)
            {
                bool hasManyCategories = false;
                int categoryId = -1;
                foreach (var detail in TransactionDetails)
                {
                    if (TotalAmount == 0)
                        TotalAmount += detail.Amount;
                    if (categoryId == -1)
                        categoryId = detail.CategoryId;
                    else if (categoryId != detail.CategoryId)
                        hasManyCategories = true;
                }
                CategoryId = hasManyCategories ? (byte)0/*Multiple*/ : (byte)categoryId;
            }
        }
    }
}
