using ETicaretApi.Entities;
using FluentValidation;

namespace ETicaretApi.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {

            RuleFor(x => x.Name)
                .NotNull()
                .WithMessage("İsim Boş Olamaz")
                .MinimumLength(3)
                .WithMessage("isim 3 Karakterden fazla olmalı");


        }
    }
}
