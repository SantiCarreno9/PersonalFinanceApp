using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace BaseLibrary.Entities
{
    public class Category
    {
        [Key]        
        public byte Id { get; set; }        
        public byte? TransactionTypeId { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string Name { get; set; }

        [ForeignKey(nameof(TransactionTypeId))]
        [JsonIgnore]
        public TransactionType? TransactionType { get; set; }
    }
}
