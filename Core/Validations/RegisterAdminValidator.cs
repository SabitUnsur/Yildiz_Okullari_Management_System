using Core.ViewModels;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Validations
{
    public class RegisterAdminValidator:AbstractValidator<RegisterAdminViewModel>
    {
        public RegisterAdminValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Lütfen isim giriniz.").NotNull().WithMessage("Lütfen isim giriniz.").MinimumLength(1).WithMessage("Lütfen en az 2 harfli isim giriniz.");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("Lütfen soyisim giriniz.").NotNull().WithMessage("Lütfen soyisim giriniz.").MinimumLength(1).WithMessage("Lütfen en az 2 harfli soyisim giriniz.");
            RuleFor(x => x.Username).NotEmpty().WithMessage("Lütfen kullanıcı adı giriniz.").NotNull().WithMessage("Lütfen kullanıcı adı giriniz.").MinimumLength(1).WithMessage("Lütfen en az 2 harfli kullanıcı adı giriniz.");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Lütfen email giriniz.").NotNull().WithMessage("Lütfen email giriniz.").EmailAddress().WithMessage("Lütfen geçerli bir email giriniz.");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Lütfen şifre giriniz.").NotNull().WithMessage("Lütfen şifre giriniz.").MinimumLength(6).WithMessage("Lütfen en az 6 haneli şifre giriniz.");
            RuleFor(x => x.PasswordConfirm).NotEmpty().WithMessage("Lütfen şifre giriniz.").NotNull().WithMessage("Lütfen şifre  giriniz.").Equal(x => x.Password).WithMessage("Şifreler uyuşmuyor. Lütfen yeniden giriniz.");
            RuleFor(x => x.PhoneNumber).NotEmpty().WithMessage("Lütfen telefon numarası giriniz.").NotNull().WithMessage("Lütfen telefon numarası giriniz.").MinimumLength(10).WithMessage("Lütfen geçerli bir telefon numarası giriniz.");
                       
        }
    }
}
