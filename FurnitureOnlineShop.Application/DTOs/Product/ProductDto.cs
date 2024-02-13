﻿using FurnitureOnlineShop.Application.DTOs.Common;

namespace FurnitureOnlineShop.Application.DTOs.Product;

public class ProductDto:BaseDto
{
    public decimal Price { get; set; }
    public string Title { get; set; }
    public string? Description { get; set; }
    public string ImagePath { get; set; }
    public int QuantityInStock { get; set; }
}
