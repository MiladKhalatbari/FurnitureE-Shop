using System.ComponentModel.DataAnnotations;

namespace FurnitureOnlineShop.MVC.Models.User
{
    public class RegisterVm
    {
        [Required]
        public string UserName { get; set; }
        [DataType(DataType.Password)]
        [Required]
        public string Password { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [EmailAddress]
        [Required]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        [Required]
        public string PasswordConfirmed { get; set; }
    }
}
