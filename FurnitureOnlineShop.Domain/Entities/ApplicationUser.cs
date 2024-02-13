using Microsoft.AspNetCore.Identity;

namespace FurnitureOnlineShop.Domain.Entities;

public class ApplicationUser : IdentityUser
{
    public string FirstName { get; set; }
    public string LastName { get; set; }

    //#region Relation
    //public List<Cart>? Carts { get; set; }
    //#endregion
}
