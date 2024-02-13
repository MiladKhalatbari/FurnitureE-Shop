using FluentValidation;

namespace FurnitureOnlineShop.Application.DTOs.Product.Validators;

public class ProductUpdateDtoValidator : AbstractValidator<ProductUpdateDto>
{
    public ProductUpdateDtoValidator()
    {

        RuleFor(p => p.Id)
       .NotEmpty().WithMessage("Product ID is required.")
       .GreaterThanOrEqualTo(0).WithMessage("Product ID must be greater than or equal to 0.");

        RuleFor(p => p.ImagePath)
            .NotEmpty().WithMessage("Image path is required.");

        RuleFor(p => p.Price)
            .NotEmpty().WithMessage("Price is required.")
            .GreaterThanOrEqualTo(0).WithMessage("Price must be greater than or equal to 0.");

        RuleFor(p => p.QuantityInStock)
            .NotEmpty().WithMessage("Quantity in stock is required.")
            .GreaterThanOrEqualTo(0).WithMessage("Quantity in stock must be greater than or equal to 0.");
    }
}
