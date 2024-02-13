using FluentValidation;
using FurnitureOnlineShop.Application.Contracts;

namespace FurnitureOnlineShop.Application.DTOs.Product.Validators;

public class ProductCreateDtoValidator : AbstractValidator<ProductCreateDto>
{
    private readonly IProductRepository _productRepository;

    public ProductCreateDtoValidator(IProductRepository productRepository )
    {
        _productRepository = productRepository;

        RuleFor(p => p.Title)
            .NotEmpty().WithMessage("Title is required.")
            .MaximumLength(512).WithMessage("Title cannot exceed 512 characters.");

        RuleFor(p => p.ImagePath)
            .NotEmpty().WithMessage("Image path is required.");

        RuleFor(p => p.Price)
            .NotEmpty().WithMessage("Price is required.")
            .GreaterThanOrEqualTo(0).WithMessage("Price must be greater than or equal to 0.");

        RuleFor(p => p.QuantityInStock)
            .NotEmpty().WithMessage("Quantity in stock is required.")
            .GreaterThanOrEqualTo(0).WithMessage("Quantity in stock must be greater than or equal to 0.");
       
        RuleFor(p => p).MustAsync(IsUniqueTitle).WithMessage("Product already exists"); ;
    }

    private async Task<bool> IsUniqueTitle(ProductCreateDto dto, CancellationToken token)
    {
        return await _productRepository.isUniqueTitleAsync(dto.Title);
    }
}
