using AutoMapper;
using FurnitureOnlineShop.MVC.Models.Product;
using FurnitureOnlineShop.MVC.Services.Base;

namespace FurnitureOnlineShop.MVC.MappingProfiles
{
    public class ProductProfiles:Profile
    {
        public ProductProfiles()
        {
            CreateMap<ProductDto, ProductVm>().ReverseMap();
            CreateMap<ProductUpdateVm, ProductVm>().ReverseMap();
            CreateMap<ProductCreateDto, ProductCreateVm>().ReverseMap();
            CreateMap<ProductUpdateDto, ProductUpdateVm>().ReverseMap();


        }
    }
}
