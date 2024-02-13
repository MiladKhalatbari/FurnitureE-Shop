using AutoMapper;
using FurnitureOnlineShop.Application.DTOs.Cart;
using FurnitureOnlineShop.Domain.Entities;

namespace FurnitureOnlineShop.Application.MappingProfiles;

public class CartProfiles : Profile
{
    public CartProfiles()
    {
        CreateMap<Cart, CartDto>().ReverseMap();
        CreateMap<Cart, CartCreateDto>().ReverseMap();
        CreateMap<Cart, CartUpdateDto>().ReverseMap();
    }
}