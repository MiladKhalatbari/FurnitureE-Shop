using FurnitureOnlineShop.Domain.Entities.Common;

namespace FurnitureOnlineShop.Domain.Entities;

public class CartItem:BaseEntity
{
    public int Quantity { get; set; }
    public int CartId { get; set;}
    public int ProductId { get; set;}
    public decimal TotalPrice => Quantity * Product.Price;

    #region Relation
    public Cart Cart { get; set;}
    public Product Product { get; set; }
    #endregion
}
