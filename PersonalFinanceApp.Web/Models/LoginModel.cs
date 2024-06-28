using System.ComponentModel.DataAnnotations;

namespace PersonalFinanceApp.Web.Models
{
    public class LoginModel
    {
        [EmailAddress, Required]
        public string EmailAddress { get; set; }
        [Required, DataType(DataType.Password)]
        public string Password { get; set; }        
    }
}
