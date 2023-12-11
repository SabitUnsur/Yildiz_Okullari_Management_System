using Business.Abstract;
using Core.ViewModels;
using Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class RoleService : IRoleService
    {
        private readonly RoleManager<AppRole> _roleManager;
        private readonly UserManager<Person> _userManager;

        public RoleService(RoleManager<AppRole> roleManager, UserManager<Person> userManager)
        {
            _roleManager=roleManager;
            _userManager=userManager;
        }
        public async Task AssignRoleAsync(Guid id, List<AssignToRoleViewModel> request)
        {
            var user = await _userManager.FindByNameAsync(id.ToString());
            foreach(var role in request)
            {
                if (role.Exist)
                {
                    await _userManager.AddToRoleAsync(user, role.Name);
                }
                else await _userManager.RemoveFromRoleAsync(user, role.Name);
            }
        }

        public async Task<(bool, IEnumerable<IdentityError>?)> CreateRoleAsync(RoleCreateViewModel request)
        {
            var result = await _roleManager.CreateAsync(new AppRole() { Name=request.Name });

            if (!result.Succeeded)
            {
                return (false, result.Errors);
            }
            else return (true, null);
        }

        public async Task<(bool, IEnumerable<IdentityError>?)> DeleteRoleAsync(Guid id)
        {
            var role = await _roleManager.FindByIdAsync(id.ToString());

            var result = await _roleManager.DeleteAsync(role);
            if (!result.Succeeded)
            {
                return (false, result.Errors);

            }
            else { return (true, null); }
        }

        public async Task<(bool, RoleUpdateViewModel?)> FindByIdReturnRoleUpdateViewModelAsync(Guid id)
        {
            var role = await _roleManager.FindByIdAsync(id.ToString());
            if (role==null)
            {
                return (false, null);
            }
            var roleUpdateViewModel = new RoleUpdateViewModel() { Id=role.Id, Name=role.Name };
            return (true, roleUpdateViewModel);
        }

        public async Task<List<AssignToRoleViewModel>> GetRoleByIdReturnAssignToRoleAsync(Guid id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());

            var roles = await _roleManager.Roles.ToListAsync();

            var roleViewModel = new List<AssignToRoleViewModel>();

            var userRoles = await _userManager.GetRolesAsync(user);

            foreach (var role in roles)
            {
                var assignToRoleViewModel = new AssignToRoleViewModel() { Id=role.Id, Name=role.Name };
                if (userRoles.Contains(role.Name))
                {
                    assignToRoleViewModel.Exist = true;
                }
                roleViewModel.Add(assignToRoleViewModel);
            }
            return roleViewModel;
        }

        
        public async Task<List<RoleViewModel>> GetRoleListAsync()
        {
            var roles = await _roleManager.Roles.AsNoTracking().ToListAsync();
            var roleViewModel= roles.Select(x => new RoleViewModel() { Id=x.Id, Name=x.Name, }).ToList();
            return roleViewModel;
        }

        public async Task<(bool, IEnumerable<IdentityError>?)> UpdateRoleAsync(RoleUpdateViewModel request)
        {
            var role = await _roleManager.FindByIdAsync(request.Id.ToString());
            if (role==null)
            {
                return (false, null);
            }
            role.Name=request.Name;
            var result = await _roleManager.UpdateAsync(role);
            if (!result.Succeeded) { return (false, result.Errors); }

            else { return (true, null); }
        }
    }
}
