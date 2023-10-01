using E_Commerce.Application.Features.Command.Product.CreateProduct;
using FluentValidation;

namespace E_Commerce.Application.Validations.ProductValidation
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommandRequest>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(x => x.Name)
           .NotEmpty().WithMessage("Ürün adı boş olamaz.")
           .MaximumLength(255).WithMessage("Ürün adı 255 karakteri geçemez.");

            RuleFor(x => x.Price)
                .GreaterThan(0).WithMessage("Ürün fiyatı sıfırdan büyük olmalıdır.");

            RuleFor(x => x.Stock)
                      .GreaterThanOrEqualTo(0).WithMessage("Ürün stok miktarı negatif olamaz.");
        }
    }
}
