using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace BaseLibrary.Entities
{
    public class TransactionDetail
    {
        [Key]
        public int Id { get; set; }        
        public long TransactionId { get; set; }        
        public int CategoryId { get; set; }
        [Column(TypeName = "nvarchar(400)")]
        public string? Description { get; set; }
        [DataType(DataType.Currency)]
        public decimal Amount { get; set; }
        
        [JsonIgnore]
        public Transaction Transaction { get; set; } = null!;
        [JsonIgnore]
        public Category Category { get; set; }
    }
}
