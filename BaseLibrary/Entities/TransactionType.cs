using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BaseLibrary.Entities
{
    public class TransactionType
    {
        [Key]
        public byte Id { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string Name { get; set; }        
        public ICollection<Category> Categories { get; set; }
    }
}
