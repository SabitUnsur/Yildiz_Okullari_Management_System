using Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Validations
{
    public class UserValidator : IUserValidator<Person>
    {
        public async Task<IdentityResult> ValidateAsync(UserManager<Person> manager, Person user)
        {
            var errors=new List<IdentityError>();
            var isDigit = int.TryParse(user.UserName![0].ToString(), out _ );//kullanıcı adı rakamla başlıyor mu
            
            if (isDigit)
            {
                errors.Add(new IdentityError() { Code="StartWithDigit",Description="Kullanıcı adı rakamla başlayamaz"});
            }
           
            if (errors.Count==0)
            {
                return IdentityResult.Success;
            }
            else
            {
                return IdentityResult.Failed(errors.ToArray());
            }

        }
    }
}
