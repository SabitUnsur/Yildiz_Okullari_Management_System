using Business.Abstract;
using Core.ViewModels;
using Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class LoginService : ILoginService
    {
        private readonly UserManager<Person> _userManager;
        private readonly SignInManager<Person> _signInManager;

        public LoginService(UserManager<Person> userManager, SignInManager<Person> signInManager)
        {
            _userManager=userManager;
            _signInManager=signInManager;
        }

        public async Task<Person> FindByEmailAsync(string email)
        {
            return await _userManager.FindByEmailAsync(email);
        }
        public async Task<bool> LoginAsync(LoginViewModel request, Person user)
        {
            var result = await _signInManager.PasswordSignInAsync(user, request.Password!, request.RememberMe, true);
            if(result.Succeeded)
            {
                return true;
            }
            return false;
        }
        public async Task<string> GeneratePasswordResetTokenAsync(Guid userid)
        {
            var user = await _userManager.FindByIdAsync(userid.ToString());
            return await _userManager.GeneratePasswordResetTokenAsync(user!);
        }   
    }
}
