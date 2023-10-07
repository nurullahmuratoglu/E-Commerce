using E_Commerce.Application.Features.Command.Category.CreateCategory;
using FluentValidation;

namespace E_Commerce.Application.Validations.CategoryValidation
{
    public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommandRequest>
    {
        public CreateCategoryCommandValidator()
        {
            RuleFor(request => request.Name)
                .NotEmpty().WithMessage("kategori adı boş olamaz.");
        }
    }
}
