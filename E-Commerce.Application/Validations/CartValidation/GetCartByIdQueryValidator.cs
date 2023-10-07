using E_Commerce.Application.Features.Queries.Cart.GetCartById;
using FluentValidation;

namespace E_Commerce.Application.Validations.CartValidation
{
    public class GetCartByIdQueryValidator : AbstractValidator<GetCartByIdQueryRequest>
    {
        public GetCartByIdQueryValidator()
        {
            RuleFor(request => request)
                .Must(request => (request.GuestId != null && request.UserId == null) || (request.GuestId == null && request.UserId != null))
                .WithMessage("GuestId ve UserId aynı anda belirtilmemelidir.");
        }
    }
}

