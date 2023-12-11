using Core.ViewModels;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IRoleService
    {
        Task<List<RoleViewModel>> GetRoleListAsync();
        Task<(bool, IEnumerable<IdentityError>?)> CreateRoleAsync(RoleCreateViewModel request);
        Task<(bool, RoleUpdateViewModel?)> FindByIdReturnRoleUpdateViewModelAsync(Guid id);
        Task<(bool, IEnumerable<IdentityError>?)> UpdateRoleAsync(RoleUpdateViewModel request);
        Task<(bool, IEnumerable<IdentityError>?)> DeleteRoleAsync(Guid id);
        Task<List<AssignToRoleViewModel>> GetRoleByIdReturnAssignToRoleAsync(Guid id);
        Task AssignRoleAsync(Guid id, List<AssignToRoleViewModel> request);
    }
}
