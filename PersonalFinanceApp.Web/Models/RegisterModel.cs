using System.ComponentModel.DataAnnotations;

namespace PersonalFinanceApp.Web.Models
{
    public class RegisterModel
    {
        [Required,MinLength(3)]
        public string UserName { get; set; }
        [EmailAddress, Required]
        public string EmailAddress { get; set; }
        [Required, DataType(DataType.Password), MinLength(7)]
        public string Password { get; set; }
        [Required, DataType(DataType.Password), MinLength(7)]
        public string ConfirmPassword { get; set; }
    }
}
