using FurnitureOnlineShop.MVC.Models.Product;
using FurnitureOnlineShop.MVC.Services.Base;

namespace FurnitureOnlineShop.MVC.Contracts
{
    public interface IProductService
    {
        public Task<ProductVm> GetAsync(int id);
        public Task<IReadOnlyList<ProductVm>> GetAllAsync();
        public Task<Response<int>> AddAsync(ProductCreateVm item);
        public Task<Response<int>> UpdateAsync(ProductUpdateVm entity);
        public Task<Response<int>> DeleteAsync(int id);
    }
}
