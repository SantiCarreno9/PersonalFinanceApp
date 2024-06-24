using System.ComponentModel.DataAnnotations.Schema;

namespace BaseLibrary.Entities
{
    public class TransactionType
    {
        public int Id { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string Name { get; set; }
    }
}
