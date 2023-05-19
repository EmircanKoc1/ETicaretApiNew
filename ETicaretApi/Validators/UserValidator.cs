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
                .NotEmpty()
                .WithMessage("İsim Boş Olamaz")
                .MinimumLength(3)
                .WithMessage("isim 3 Karakterden fazla olmalı")
                .MaximumLength(16)
                .WithMessage("İsim en fazla 16 karakter olmalı");
            RuleFor(x => x.SurName)
                .NotNull()
                .NotEmpty()
                .WithMessage("Soyad alanı boş geçilemez")
                .MinimumLength(1)
                .WithMessage("Soyadınız bir karakterden fazla olmalıdır")
                .MaximumLength(50)
                .WithMessage("Soyadınız en fazla 50 karakter olabilir");
            RuleFor(x => x.Email)
                .NotEmpty()
                .NotNull()
                .WithMessage("Email alanı boş bırakılamaz")
                .MinimumLength(3)
                .WithMessage("Email 3 karakterden fazla olmalıdır")
                .MaximumLength(50)
                .WithMessage("Email 50 karakterden fazla olmalıdır")
                .EmailAddress()
                .WithMessage("Lütfen geçerli bir mail adresi giriniz");
            RuleFor(x => x.UserName)
                .NotNull()
                .NotEmpty()
                .WithMessage("Lütfen kullanıcı adı alanını boş geçmeyin")
                .MinimumLength(3)
                .WithMessage("Kullanıcı adınız 3 karakterden fazla olmalıdır")
                .MaximumLength(16)
                .WithMessage("Kullanıcı adınız 50 karakterden fazla olmalıdır");
            RuleFor(x => x.Adress)
                .NotNull()
                .NotEmpty()
                .WithMessage("Adres alanını boş bırakmayınız")
                .MinimumLength(3)
                .WithMessage("Adres bilginiz 3 karakterden fazla olmalıdır")
                .MaximumLength(200)
                .WithMessage("Adres bilginiz 200 karakterden fazla olamaz");
            RuleFor(x => x.PhoneNumber)
                .NotNull()
                .NotEmpty()
                .WithMessage("Lütfen telefon numarası alanını boş bırakmayın")
                .Length(11, 11)
                .WithMessage("Lütfen geçerli bir telefon numarası girin");
            RuleFor(x => x.ImgSrc)
                .NotEmpty()
                .NotNull()
                .WithMessage("Lütfen resim alanını boş bırakmayın");



        }
    }
}
