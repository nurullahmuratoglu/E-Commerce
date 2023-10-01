using E_Commerce.Application.Features.Command.User.UserAuthentication;
using FluentValidation;

namespace E_Commerce.Application.Validations.UserValidation
{
    public class UserAuthQueryValidator : AbstractValidator<UserAuthQueryRequest>
    {
        public UserAuthQueryValidator()
        {
            RuleFor(x => x.Password)
    .NotEmpty().WithMessage("Şifre alanı boş olamaz.")
    .MinimumLength(10).WithMessage("Şifre en az 10 karakter olmalıdır.")
    .Matches("[A-Z]").WithMessage("Şifre en az bir büyük harf içermelidir.")
    .Matches("[0-9]").WithMessage("Şifre en az bir rakam içermelidir.");


            RuleFor(x => x.Email)
           .NotEmpty().WithMessage("Email alanı boş olamaz.")
           .EmailAddress().WithMessage("Geçersiz email formatı.");



        }
    }
}
