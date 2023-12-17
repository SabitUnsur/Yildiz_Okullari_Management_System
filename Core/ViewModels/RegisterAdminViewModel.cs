using Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.ViewModels
{
    public class RegisterAdminViewModel
    {
        public RegisterAdminViewModel()
        {
            
        }

        public RegisterAdminViewModel(string? name, string? surname, string? username, int grade , string branch ,string? email, string? password, string? passwordConfirm, string? phoneNumber, Guid termId)
        {
            Name=name;
            Surname=surname;
            Username=username;
            Email=email;
            Password=password;
            PasswordConfirm=passwordConfirm;
            PhoneNumber=phoneNumber;
            TermId=termId;
        }
        [Required(ErrorMessage ="İsim alanı boş bırakılamaz")]
        [Display(Name="İsim")]
        public string? Name { get; set; }
        [Required(ErrorMessage ="Soyisim alanı boş bırakılamaz")]
        [Display(Name="Soyisim")]
        public string? Surname { get; set; }
        [Required(ErrorMessage ="Kullanıcı adı alanı boş bırakılamaz")]
        [Display(Name="Kullanıcı Adı")]
        public string? Username { get; set; }
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage ="Email alanı boş bırakılamaz")]
        [EmailAddress(ErrorMessage ="Lütfen geçerli bir email giriniz.")]
        [Display(Name="Email")]
        public string? Email { get; set; }
        [Required(ErrorMessage ="Şifre alanı boş bırakılamaz")]
        [DataType(DataType.Password)]
        [Display(Name="Şifre")]
        public string? Password { get; set; }
        [Required(ErrorMessage ="Şifre tekrar alanı boş bırakılamaz")]
        [DataType(DataType.Password)]
        [Display(Name="Şifre Tekrar")]
        public string? PasswordConfirm { get; set; }
        [Required(ErrorMessage ="Telefon numarası alanı boş bırakılamaz")]
        [Display(Name="Telefon Numarası")]
        public string? PhoneNumber { get; set; }
        public Guid? TermId { get; set; }
    }
}
