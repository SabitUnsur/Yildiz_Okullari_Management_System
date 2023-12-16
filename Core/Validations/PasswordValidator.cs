using Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Validations
{
    public class PasswordValidator : IPasswordValidator<Person>
    {
        public Task<IdentityResult> ValidateAsync(UserManager<Person> manager, Person user, string? password)
        {
            var errors=new List<IdentityError>();
            if (password!.Length<6)
            {
                errors.Add(new IdentityError() { Code="PasswordLength",Description="Şifre en az 6 karakter olmalıdır"});
            }
            if (password.ToLower().Contains(user.UserName!.ToLower()))
            {
                errors.Add(new IdentityError() { Code="PasswordContainsUserName",Description="Şifre kullanıcı adı içeremez"});
            }
            if (password.Contains("1234"))
            {
                errors.Add(new IdentityError() { Code="PasswordContains1234",Description="Şifre ardışık sayı içeremez"});
            }
            if (password.Contains(user.Name!.ToLower()))
            {
                errors.Add(new IdentityError() { Code="PasswordContainsName",Description="Şifre isim içeremez"});
            }
            if (password.Contains(user.Surname!.ToLower()))
            {
                errors.Add(new IdentityError() { Code="PasswordContainsSurname",Description="Şifre soyisim içeremez"});
            }
            if (password.Contains(user.Email!.ToLower()))
            {
                errors.Add(new IdentityError() { Code="PasswordContainsEmail",Description="Şifre email içeremez"});
            }
            if (password.Contains(user.PhoneNumber!))
            {
                errors.Add(new IdentityError() { Code="PasswordContainsPhoneNumber",Description="Şifre telefon numarası içeremez"});
            }
            if (errors.Count==0)
            {
                return Task.FromResult(IdentityResult.Success);
            }
            else
            {
                return Task.FromResult(IdentityResult.Failed(errors.ToArray()));
            }
        }
    }
}
