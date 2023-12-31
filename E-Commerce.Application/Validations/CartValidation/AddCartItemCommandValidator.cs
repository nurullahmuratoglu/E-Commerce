﻿using E_Commerce.Application.Features.Command.Cart.AddCartItem;
using FluentValidation;

namespace E_Commerce.Application.Validations.CartValidation
{
    public class AddCartItemCommandValidator : AbstractValidator<AddCartItemCommandRequest>
    {
        public AddCartItemCommandValidator()
        {
            RuleFor(request => request.Quantity)
                .GreaterThan(0).WithMessage("Ürün adeti sıfırdan büyük olmalıdır.");

            RuleFor(request => request)
                .Must(request => (request.GuestId != null && request.UserId == null) || (request.GuestId == null && request.UserId != null))
                .WithMessage("GuestId ve UserId aynı anda belirtilmemelidir.");
        }
    }
}
