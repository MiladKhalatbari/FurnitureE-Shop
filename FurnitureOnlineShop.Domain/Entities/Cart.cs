using FurnitureOnlineShop.Domain.Entities.Common;
using Microsoft.AspNetCore.Identity;

namespace FurnitureOnlineShop.Domain.Entities;

public class Cart : BaseEntity
{
    public bool IsFinaly { get; set; }
    public string IdentityUserId { get; set; }
    public decimal TotalPrice => cartItems.Sum(ci => ci.TotalPrice);
    public void AddToCart(Product product)
    {
        if (cartItems.Any(ci => ci.ProductId == product.Id))
            cartItems.First(ci => ci.ProductId == product.Id).Quantity++;
        else
            cartItems.Add(new CartItem()
            {
                CartId = Id,
                CreatedDate = DateTime.Now,
                ProductId = product.Id,
                Quantity = 1,
            });
    }
    public void RemoveFromCart(Product product)
    {
        var cartItem = cartItems.FirstOrDefault(ci => ci.ProductId == product.Id);

        if (cartItem != null && cartItem.Quantity > 1)
            cartItem.Quantity--;

        else if (cartItem != null)
            cartItems.Remove(cartItem);
    }
    #region Relation
    public List<CartItem>? cartItems { get; set; }
    public IdentityUser? IdentityUser { get; set; }
    #endregion

}
