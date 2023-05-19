using ETicaretApi.Entities;
using FluentValidation;

namespace ETicaretApi.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {

            RuleFor(x => x.Name).NotNull().WithMessage("Email Boş Olamaz");



        }
    }
}
