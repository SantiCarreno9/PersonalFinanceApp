using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace BaseLibrary.Entities
{
    public class Transaction
    {
        [Key]
        public long Id { get; set; }
        [Column(TypeName = "nvarchar(450)")]
        public string UserId { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; } = DateTime.Now;
        [DataType(DataType.Currency)]
        public decimal TotalAmount { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string? Location { get; set; }
        public int CategoryId { get; set; }

        public int TransactionTypeId { get; set; }
        public int PaymentMethodId { get; set; }

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
                CategoryId = hasManyCategories ? 1/*Multiple*/ : categoryId;
            }
        }
    }
}
