using ETicaretApi.Entities;
using FluentValidation;

namespace ETicaretApi.Validators
{    //Fluent Validation Kutuphanesi ile User kullanarak yapılan işlemlerde belirli kontroller sağladık.
    //Çalışması için AbstractValidator a ilgili Sınıf verilerek kalıtım sağlanıyor.
    //Kontrollerde aşağıdaki gibi.
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {

            RuleFor(x => x.Name)
                .NotNull()
                .NotEmpty()
                .WithMessage("Lütfen ad alanını boş geçmeyin")
                .MinimumLength(3)
                .WithMessage("Adınız 3 Karakterden fazla olmalı")
                .MaximumLength(16)
                .WithMessage("Adınız en fazla 16 karakter olmalı");
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
            //RuleFor(x => x.Adress)
            //    .NotNull()
            //    .NotEmpty()
            //    .WithMessage("Adres alanını boş bırakmayınız")
            //    .MinimumLength(3)
            //    .WithMessage("Adres bilginiz 3 karakterden fazla olmalıdır")
            //    .MaximumLength(200)
            //    .WithMessage("Adres bilginiz 200 karakterden fazla olamaz");
            RuleFor(x => x.PhoneNumber)
                .NotNull()
                .NotEmpty()
                .WithMessage("Lütfen telefon numarası alanını boş bırakmayın")
                .Length(11, 11)
                .WithMessage("Lütfen geçerli bir telefon numarası girin");
            //RuleFor(x => x.ImgSrc)
            //    .NotEmpty()
            //    .NotNull()
            //    .WithMessage("Lütfen resim alanını boş bırakmayın");
            RuleFor(x => x.Password)
                .NotEmpty()
                .NotNull()
                .WithMessage("Şifre alanı boş geçilemez")
                .MinimumLength(6)
                .WithMessage("Şifreniz 6 veya 6 karakterden fazla olmalı")
                .MaximumLength(16)
                .WithMessage("Şifreniz 16 karakter veya 16 karakterden kısa olmalıdır");


        }
    }
}
