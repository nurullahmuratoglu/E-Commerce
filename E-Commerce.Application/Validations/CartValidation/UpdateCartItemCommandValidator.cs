using E_Commerce.Application.Features.Command.Cart.UpdateCartProduct;
using FluentValidation;

namespace E_Commerce.Application.Validations.CartValidation
{
    public class UpdateCartItemCommandValidator:AbstractValidator<UpdateCartItemCommandRequest>
    {
        public UpdateCartItemCommandValidator()
        {
            RuleFor(request => request.Quantity)
                .GreaterThan(0).WithMessage("Ürün adeti sıfırdan büyük olmalıdır.");
            RuleFor(request => request)
                .Must(request => (request.GuestId != null && request.UserId == null) || (request.GuestId == null && request.UserId != null))
                .WithMessage("GuestId ve UserId aynı anda belirtilmemelidir.");
        }
    }
}
