using E_Commerce.Application.Features.Command.Product.CreateProduct;
using FluentValidation;

namespace E_Commerce.Application.Validations.ProductValidation
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommandRequest>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(request => request.Name)
                .NotEmpty().WithMessage("Ürün adı boş olamaz.")
                .MaximumLength(255).WithMessage("Ürün adı 255 karakteri geçemez.");

            RuleFor(request => request.Price)
                .GreaterThan(0).WithMessage("Ürün fiyatı sıfırdan büyük olmalıdır.");

            RuleFor(request => request.Stock)
                .GreaterThanOrEqualTo(0).WithMessage("Ürün stok miktarı negatif olamaz.");
        }
    }
}
