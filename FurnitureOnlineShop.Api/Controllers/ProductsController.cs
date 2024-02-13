using FurnitureOnlineShop.Application.DTOs.Product;
using FurnitureOnlineShop.Application.Features.Product.Command.CreateProduct;
using FurnitureOnlineShop.Application.Features.Product.Command.DeleteProduct;
using FurnitureOnlineShop.Application.Features.Product.Command.UpdateProduct;
using FurnitureOnlineShop.Application.Features.Product.Query.GetAllFavoriteProducts;
using FurnitureOnlineShop.Application.Features.Product.Query.GetAllProducts;
using FurnitureOnlineShop.Application.Features.Product.Query.GetProduct;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace FurnitureOnlineShop.Api.Controllers;

[Route("api/[controller]/[Action]")]
[ApiController]
[Authorize]
public class ProductsController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProductsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<List<ProductDto>>> Get()
    {
        return Ok(await _mediator.Send(new GetAllProductsRequest()));
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<List<ProductDto>>> GetFavorites()
    {
        return Ok(await _mediator.Send(new GetAllFavoriteProductsRequest()));
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult<ProductDto>> Get(int id)
    {
        return Ok(await _mediator.Send(new GetProductRequest(id)));
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> Post([FromBody] ProductCreateDto createDto)
    {
        var productId = await _mediator.Send(new CreateProductCommand(createDto));
        return CreatedAtAction(nameof(Get),new { id = productId });
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> Put([FromBody] ProductUpdateDto  updateDto)
    {
        await _mediator.Send(new UpdateProductCommand(updateDto));
        return Ok();
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> Delete(int id)
    {
        await _mediator.Send(new DeleteProductCommand(id));
        return Ok();
    }
}
