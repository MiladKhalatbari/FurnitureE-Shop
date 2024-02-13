using System.ComponentModel.DataAnnotations;

namespace FurnitureOnlineShop.MVC.Models.User
{
    public class LoginVm
    {     
        [Required]
        public string UserName { get; set; }
        [DataType(DataType.Password)]
        [Required]
        public string Password { get; set; }
        public string? returnUrl { get; set; }
        
    }
}
