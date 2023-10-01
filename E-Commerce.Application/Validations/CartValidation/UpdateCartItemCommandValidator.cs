using E_Commerce.Application.Features.Command.Cart.UpdateCartProduct;
using FluentValidation;

namespace E_Commerce.Application.Validations.CartValidation
{
    public class UpdateCartItemCommandValidator:AbstractValidator<UpdateCartItemCommandRequest>
    {
        public UpdateCartItemCommandValidator()
        {
            RuleFor(x => x.Quantity).GreaterThan(0).WithMessage("Ürün adeti sıfırdan büyük olmalıdır.");   
        }
    }
}
