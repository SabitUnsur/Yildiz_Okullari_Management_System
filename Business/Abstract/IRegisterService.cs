using Core.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IRegisterService
    {
        Task<(bool, IEnumerable<IdentityError>?)> RegisterStudentAsync(RegisterStudentViewModel request);
        Task<(bool, IEnumerable<IdentityError>?)> RegisterAdminAsync(RegisterAdminViewModel request);
        SelectList GetGenderSelectList();
    }
}
