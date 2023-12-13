using Core.ViewModels;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Validations
{
    public class RegisterStudentValidator:AbstractValidator<RegisterStudentViewModel>
    {
        public RegisterStudentValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Lütfen isim giriniz.").NotNull().WithMessage("Lütfen isim giriniz.").MinimumLength(1).WithMessage("Lütfen en az 2 harfli isim giriniz.");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("Lütfen soyisim giriniz.").NotNull().WithMessage("Lütfen soyisim giriniz.").MinimumLength(1).WithMessage("Lütfen en az 2 harfli soyisim giriniz.");
            RuleFor(x => x.Username).NotEmpty().WithMessage("Lütfen kullanıcı adı giriniz.").NotNull().WithMessage("Lütfen kullanıcı adı giriniz.").MinimumLength(1).WithMessage("Lütfen en az 2 harfli kullanıcı adı giriniz.");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Lütfen email giriniz.").NotNull().WithMessage("Lütfen email giriniz.").EmailAddress().WithMessage("Lütfen geçerli bir email giriniz.");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Lütfen şifre giriniz.").NotNull().WithMessage("Lütfen şifre giriniz.").MinimumLength(6).WithMessage("Lütfen en az 6 haneli şifre giriniz.");
            RuleFor(x => x.PasswordConfirm).NotEmpty().WithMessage("Lütfen şifre giriniz.").NotNull().WithMessage("Lütfen şifre  giriniz.").Equal(x => x.Password).WithMessage("Şifreler uyuşmuyor. Lütfen yeniden giriniz.");
            RuleFor(x => x.PhoneNumber).NotEmpty().WithMessage("Lütfen telefon numarası giriniz.").NotNull().WithMessage("Lütfen telefon numarası giriniz.").MinimumLength(10).WithMessage("Lütfen geçerli bir telefon numarası giriniz.");
            RuleFor(x => x.StudentNumber.ToString()).NotEmpty().WithMessage("Lütfen öğrenci numarası giriniz.").NotNull().WithMessage("Lütfen öğrenci numarası giriniz.").MinimumLength(3).WithMessage("Lütfen en az 3 haneli öğrenci numarasını giriniz.").MaximumLength(4).WithMessage("En fazla 4 haneli öğrenci numarası girilebilir.");
            RuleFor(x => x.Grade).NotEmpty().WithMessage("Lütfen sınıf seçiniz.").NotNull().WithMessage("Lütfen sınıf seçiniz.");
            RuleFor(x => x.Branch).NotEmpty().WithMessage("Lütfen şube seçiniz.").NotNull().WithMessage("Lütfen şube seçiniz.");
            RuleFor(x => x.FatherFullName).NotEmpty().WithMessage("Lütfen baba adı giriniz.").NotNull().WithMessage("Lütfen baba adı giriniz.").MinimumLength(1).WithMessage("Lütfen en az 2 harfli baba adı giriniz.");
            RuleFor(x => x.MotherFullName).NotEmpty().WithMessage("Lütfen anne adı giriniz.").NotNull().WithMessage("Lütfen anne adı giriniz.").MinimumLength(1).WithMessage("Lütfen en az 2 harfli anne adı giriniz.");
            RuleFor(x => x.FatherPhoneNumber).NotEmpty().WithMessage("Lütfen baba telefon numarası giriniz.").NotNull().WithMessage("Lütfen baba telefon numarası giriniz.").MinimumLength(10).WithMessage("Lütfen geçerli bir baba telefon numarası giriniz.");
            RuleFor(x => x.MotherPhoneNumber).NotEmpty().WithMessage("Lütfen anne telefon numarası giriniz.").NotNull().WithMessage("Lütfen anne telefon numarası giriniz.").MinimumLength(10).WithMessage("Lütfen geçerli bir anne telefon numarası giriniz.");
            RuleFor(x=>x.Gender).NotEmpty().WithMessage("Lütfen cinsiyet seçiniz.").NotNull().WithMessage("Lütfen cinsiyet seçiniz.");
            RuleFor(x=>x.BirthDate).NotEmpty().WithMessage("Lütfen doğum tarihi seçiniz.").NotNull().WithMessage("Lütfen doğum tarihi seçiniz.");
           
        }
    }
}
