using AutoMapper;
using FurnitureOnlineShop.MVC.Contracts;
using FurnitureOnlineShop.MVC.Models.Product;
using FurnitureOnlineShop.MVC.Services.Base;

namespace FurnitureOnlineShop.MVC.Services;

public class ProductService : BaseHttpService, IProductService
{
    private readonly IMapper _mapper;

    public ProductService(IMapper mapper, IClient client, ILocalStorageService localStorage) : base(client, localStorage)
    {
        _mapper = mapper;
    }

    public async Task<Response<int>> AddAsync(ProductCreateVm item)
    {
        try
        {
            var response = new Response<int>();
            ProductCreateDto productCreateDto = _mapper.Map<ProductCreateDto>(item);

            AddBearerToken();

            await _client.PostAsync(productCreateDto);

            return new Response<int> { Success = true };
        }
        catch (ApiException ex)
        {
            return ConvertApiExceptions<int>(ex);
        }
    }

    public async Task<Response<int>> DeleteAsync(int id)
    {
        try
        {
            AddBearerToken();
            await _client.DeleteAsync(id);
            return new Response<int> { Success = true };
        }
        catch (ApiException ex)
        {
            return ConvertApiExceptions<int>(ex);
        }
    }

    public async Task<IReadOnlyList<ProductVm>> GetAllAsync()
    {
        AddBearerToken();
        var productDtos = await _client.GetAllAsync();
        var productVms = _mapper.Map<List<ProductVm>>(productDtos);
        return productVms;
    }

    public async Task<ProductVm> GetAsync(int id)
    {
        AddBearerToken();
        var productDto = await _client.GetAsync(id);
        var productVm = _mapper.Map<ProductVm>(productDto);
        return productVm;
    }

    public async Task<Response<int>> UpdateAsync(ProductUpdateVm entity)
    {
        try
        {
            ProductUpdateDto productDto = _mapper.Map<ProductUpdateDto>(entity);
            AddBearerToken();
            await _client.PutAsync(productDto);
            return new Response<int> { Success = true };
        }
        catch (ApiException ex)
        {
            return ConvertApiExceptions<int>(ex);
        }
    }
}
