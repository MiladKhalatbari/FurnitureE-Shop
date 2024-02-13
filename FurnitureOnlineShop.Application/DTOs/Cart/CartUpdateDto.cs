using FurnitureOnlineShop.Application.DTOs.Common;

namespace FurnitureOnlineShop.Application.DTOs.Cart;

public class CartUpdateDto : BaseDto
{
    public bool IsFinaly { get; set; }
}
