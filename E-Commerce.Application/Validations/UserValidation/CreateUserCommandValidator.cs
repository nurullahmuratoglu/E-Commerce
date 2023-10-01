using E_Commerce.Application.Features.Command.User.CreateUser;
using FluentValidation;

namespace E_Commerce.Application.Validations.UserValidation
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommandRequest>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(x => x.Email)
                       .NotEmpty().WithMessage("Email alanı boş olamaz.")
                       .EmailAddress().WithMessage("Geçersiz email formatı.");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Şifre alanı boş olamaz.")
                .MinimumLength(10).WithMessage("Şifre en az 10 karakter olmalıdır.")
                .Matches("[A-Z]").WithMessage("Şifre en az bir büyük harf içermelidir.")
                .Matches("[0-9]").WithMessage("Şifre en az bir rakam içermelidir.");

            RuleFor(x => x.ConfirmPassword)
                .Equal(x => x.Password).WithMessage("Şifreler uyuşmuyor.");

            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("Ad alanı boş olamaz.");

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Soyad alanı boş olamaz.");

            RuleFor(x => x.City)
                .NotEmpty().WithMessage("Şehir alanı boş olamaz.");
        }
    }
}
