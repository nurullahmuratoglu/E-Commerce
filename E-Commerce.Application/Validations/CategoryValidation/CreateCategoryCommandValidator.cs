using E_Commerce.Application.Features.Command.Category.CreateCategory;
using FluentValidation;

namespace E_Commerce.Application.Validations.CategoryValidation
{
    public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommandRequest>
    {
        public CreateCategoryCommandValidator()
        {
            RuleFor(x => x.Name)
.NotEmpty().WithMessage("Ürün adı boş olamaz.");
        }
    }
}
