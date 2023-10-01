
using E_Commerce.Application.Features.Command.Cart.CreateCart;
using FluentValidation;

namespace E_Commerce.Application.Validations.CartValidation
{
    public class CreateCartCommandValidator : AbstractValidator<CreateCarttCommandRequest>
    {
        public CreateCartCommandValidator()
        {
            RuleFor(x => x.Quantity).GreaterThan(0).WithMessage("Ürün adeti sıfırdan büyük olmalıdır.");
        }
    }
}
