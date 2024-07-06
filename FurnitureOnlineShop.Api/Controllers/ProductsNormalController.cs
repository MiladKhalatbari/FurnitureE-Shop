using AutoMapper;
using FurnitureOnlineShop.Application.Contracts;
using FurnitureOnlineShop.Application.DTOs.Product;
using FurnitureOnlineShop.Application.DTOs.Product.Validators;
using FurnitureOnlineShop.Application.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FurnitureOnlineShop.Api.Controllers;

[Route("api/[controller]/[Action]")]
[ApiController]
[Authorize]
public class ProductsNormalController : Controller
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public ProductsNormalController(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<List<ProductDto>>> Get()
    {
        var products = await _productRepository.GetAllAsync();
        var data = _mapper.Map<List<ProductDto>>(products);
        return Ok(data);
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<List<ProductDto>>> GetFavorites()
    {
        var products = await _productRepository.GetAllFavoriteProductsAsync();
        var data = _mapper.Map<List<ProductDto>>(products);
        return Ok(data);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult<ProductDto>> Get(int id)
    {
        bool isExist = await _productRepository.ExistAsync(id);

        if (!isExist)
            throw new NotFoundException("We Coudnt Find the Product,The ID was not Found");
        var product = await _productRepository.GetAsync(id);
        var data = _mapper.Map<ProductDto>(product);

        return Ok(data);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> Post([FromBody] ProductCreateDto createDto)
    {
        var validator = new ProductCreateDtoValidator(_productRepository);
        var ValidationResult = await validator.ValidateAsync(createDto);
        if (!ValidationResult.IsValid)
            throw new BadRequestException("We Coudnt Create the Product,Invalid Data Exception", ValidationResult);

        var product = _mapper.Map<Domain.Entities.Product>(createDto);
        await _productRepository.UpdateAsync(product);

        return CreatedAtAction(nameof(Get), new { product.Id });
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> Put([FromBody] ProductUpdateDto updateDto)
    {
        var product = await _productRepository.GetAsync(updateDto.Id);
        if (product is null)
            throw new NotFoundException("We Coudnt Update the Product,The ID was not Found");

        var validator = new ProductUpdateDtoValidator();
        var ValidationResult = await validator.ValidateAsync(updateDto);
        if (!ValidationResult.IsValid)
            throw new BadRequestException("We Coudnt Update the Product Invald Data Exception", ValidationResult);

        var newProduct = _mapper.Map(updateDto, product);
        await _productRepository.UpdateAsync(newProduct);
        
        return Ok();
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> Delete(int id)
    {
        bool isExist = await _productRepository.ExistAsync(id);
        if (!isExist)
            throw new NotFoundException("We Coudnt Delete the Product,The ID was not Found");

        await _productRepository.DeleteAsync(id);
        return Ok();
    }
}
