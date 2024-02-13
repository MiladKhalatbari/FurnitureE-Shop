﻿using FluentValidation;

namespace FurnitureOnlineShop.Application.DTOs.Cart.Validators;

public class CartUpdateDtoValidator : AbstractValidator<CartUpdateDto>
{
    public CartUpdateDtoValidator()
    {
        RuleFor(c => c.Id)
          .NotEmpty().WithMessage("{PropertyName} Cannot be Empty")
          .GreaterThan(0).WithMessage("{PropertyName} Cannot be Negative");
    }
}
