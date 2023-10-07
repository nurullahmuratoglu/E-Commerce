using E_Commerce.Application.Features.Command.Cart.RemoveCartItem;
using FluentValidation;

namespace E_Commerce.Application.Validations.CartValidation
{
    public class RemoveCartItemCommandValidator : AbstractValidator<RemoveCartItemCommandRequest>
    {
        public RemoveCartItemCommandValidator()
        {
            RuleFor(request => request)
                .Must(request => (request.GuestId != null && request.UserId == null) || (request.GuestId == null && request.UserId != null))
                .WithMessage("GuestId ve UserId aynı anda belirtilmemelidir.");
        }
    }
}
