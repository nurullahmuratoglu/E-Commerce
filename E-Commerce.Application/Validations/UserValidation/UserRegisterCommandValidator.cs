using E_Commerce.Application.Features.Command.User.CreateUser;
using FluentValidation;

namespace E_Commerce.Application.Validations.UserValidation
{
    public class UserRegisterCommandValidator : AbstractValidator<UserRegisterCommandRequest>
    {
        public UserRegisterCommandValidator()
        {
            RuleFor(request => request.Email)
                 .NotEmpty().WithMessage("Email alanı boş olamaz.")
                 .EmailAddress().WithMessage("Geçersiz email formatı.");

            RuleFor(request => request.Password)
                .NotEmpty().WithMessage("Şifre alanı boş olamaz.")
                .MinimumLength(10).WithMessage("Şifre en az 10 karakter olmalıdır.")
                .Matches("[A-Z]").WithMessage("Şifre en az bir büyük harf içermelidir.")
                .Matches("[0-9]").WithMessage("Şifre en az bir rakam içermelidir.");

            RuleFor(request => request.ConfirmPassword)
                .Equal(x => x.Password).WithMessage("Şifreler uyuşmuyor.");

            RuleFor(request => request.FirstName)
                .NotEmpty().WithMessage("Ad alanı boş olamaz.");

            RuleFor(request => request.LastName)
                .NotEmpty().WithMessage("Soyad alanı boş olamaz.");

            RuleFor(request => request.City)
                .NotEmpty().WithMessage("Şehir alanı boş olamaz.");

            RuleFor(request => request.GuestId)
                .NotEmpty().WithMessage("Bir GuestId ile üye olunuz yapınız");
        }
    }
}
