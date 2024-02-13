using System.ComponentModel.DataAnnotations;

namespace FurnitureOnlineShop.MVC.Models.Product
{
    public class ProductUpdateVm
    {
        public int Id { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public int QuantityInStock { get; set; }
    }
}