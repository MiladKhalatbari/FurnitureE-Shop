using FurnitureOnlineShop.Domain.Entities.Common;

namespace FurnitureOnlineShop.Domain.Entities;

public class Product : BaseEntity
{
    public decimal Price { get; set; }
    public string Title { get; set; }
    public string? Description { get; set; }
    public string ImagePath { get; set; }
    public int QuantityInStock { get; set; }

    #region Relation
    public List<CartItem> CartItems { get; set; }
    #endregion

}
