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

        public RegisterAdminViewModel(string? name, string? surname, string? username, string? email, string? password, string? passwordConfirm, string? phoneNumber)
        {
            Name=name;
            Surname=surname;
            Username=username;
            Email=email;
            Password=password;
            PasswordConfirm=passwordConfirm;
            PhoneNumber=phoneNumber;
        }
        [Display(Name="İsim")]
        public string? Name { get; set; }
        [Display(Name="Soyisim")]
        public string? Surname { get; set; }
        [Display(Name="Kullanıcı Adı")]
        public string? Username { get; set; }
        [Display(Name="Email")]
        public string? Email { get; set; }
        [Display(Name="Şifre")]
        public string? Password { get; set; }
        [Display(Name="Şifre Tekrar")]
        public string? PasswordConfirm { get; set; }
        [Display(Name="Telefon Numarası")]
        public string? PhoneNumber { get; set; }
    }
}
