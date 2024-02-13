using FurnitureOnlineShop.Application.DTOs.Common;
using FurnitureOnlineShop.Domain.Entities;

namespace FurnitureOnlineShop.Application.DTOs.Cart;

public class CartDto : BaseDto
{
    public bool IsFinaly { get; set; }
    public int UserId { get; set; }
    public List<CartItem> cartItems { get; set; }

}
