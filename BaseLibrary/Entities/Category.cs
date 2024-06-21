using System.ComponentModel.DataAnnotations.Schema;

namespace BaseLibrary.Entities
{
    public class Category
    {
        public int Id { get; set; }
        [Column(TypeName ="varchar(50)")]
        public string Name { get; set; }                
    }
}
