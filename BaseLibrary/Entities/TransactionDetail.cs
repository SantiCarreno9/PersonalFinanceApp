using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace BaseLibrary.Entities
{
    public class TransactionDetail
    {
        [Key]
        public long Id { get; set; }        
        public long TransactionId { get; set; }        
        public byte CategoryId { get; set; }
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
