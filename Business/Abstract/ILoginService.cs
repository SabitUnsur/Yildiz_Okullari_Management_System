using Core.ViewModels;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ILoginService
    {
        Task<Person> FindByEmailAsync(string email);
        Task<bool> LoginAsync(LoginViewModel request, Person user);
        Task<string> GeneratePasswordResetTokenAsync(Guid userid);
    }
}
