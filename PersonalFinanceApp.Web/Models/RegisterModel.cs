using System.ComponentModel.DataAnnotations;

namespace PersonalFinanceApp.Web.Models
{
    public class RegisterModel
    {        
        [EmailAddress, Required]
        public string EmailAddress { get; set; }
        [Required, DataType(DataType.Password), MinLength(7)]
        public string Password { get; set; }
        [Required, DataType(DataType.Password), MinLength(7), Compare("Password",ErrorMessage ="Both passwords must match")]
        public string ConfirmPassword { get; set; }
    }
}
