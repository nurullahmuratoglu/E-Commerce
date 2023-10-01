using E_Commerce.Application.Features.Command.Cart.AddCartItem;
using FluentValidation;

namespace E_Commerce.Application.Validations.CartValidation
{
    public class AddCartItemCommandValidator : AbstractValidator<AddCartItemCommandRequest>
    {
        public AddCartItemCommandValidator()
        {
            RuleFor(x => x.Quantity)
.GreaterThan(0).WithMessage("Ürün adeti sıfırdan büyük olmalıdır.");
        }
    }
}
