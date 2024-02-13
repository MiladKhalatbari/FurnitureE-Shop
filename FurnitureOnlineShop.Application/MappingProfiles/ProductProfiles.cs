using AutoMapper;
using FurnitureOnlineShop.Application.DTOs.Product;
using FurnitureOnlineShop.Domain.Entities;

namespace FurnitureOnlineShop.Application.MappingProfiles;

public class ProductProfiles : Profile
{
    public ProductProfiles()
    {
        CreateMap<Product, ProductDto>().ReverseMap();
        CreateMap<Product, ProductCreateDto>().ReverseMap();
        CreateMap<Product, ProductUpdateDto>().ReverseMap();
    }
}