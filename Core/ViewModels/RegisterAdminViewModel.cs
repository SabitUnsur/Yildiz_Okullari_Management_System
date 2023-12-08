using System;
using System.Collections.Generic;
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

        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Username { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? PasswordConfirm { get; set; }
        public string? PhoneNumber { get; set; }
    }
}
