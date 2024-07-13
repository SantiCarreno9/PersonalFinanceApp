using System.ComponentModel.DataAnnotations.Schema;

namespace BaseLibrary.Entities
{
    public class PaymentMethod
    {
        public byte Id { get; set; }
        [Column(TypeName = "nvarchar(20)")]
        public string Name { get; set; }
    }
}
