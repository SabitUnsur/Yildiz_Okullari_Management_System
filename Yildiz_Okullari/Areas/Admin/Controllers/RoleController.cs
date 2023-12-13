using Business.Abstract;
using Core.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace UI.Areas.Admin.Controllers
{
    //[Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class RoleController : Controller
    {
        private readonly IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            _roleService=roleService;
        }

        public async  Task<IActionResult> RoleList()
        {
            var roles = await _roleService.GetRoleListAsync();

            return View(roles);
        }
        public IActionResult RoleCreate()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> RoleCreate(RoleCreateViewModel request)
        {
            if(!ModelState.IsValid)
            {
                return View();
            }
           var(isSuccess,error) = await _roleService.CreateRoleAsync(request);

            if (!isSuccess)
            {
                foreach (var item in error!)
                {
                    ModelState.AddModelError("", item.Description);
                }
                return View();
            }
            TempData["success"] = "Yeni Rol başarıyla oluşturuldu";
            return RedirectToAction(nameof(RoleController.RoleList));
        }

        //Burası değişebilir.
        public async Task<IActionResult> AssignToRole(Guid id)
        {
            var userRoles=await _roleService.GetRoleByIdReturnAssignToRoleAsync(id);
            ViewBag.Id=id;
            return View(userRoles);
        }
        [HttpPost]
        public async Task<IActionResult> AssignToRole(Guid id, List<AssignToRoleViewModel> requestList)
        {
            await _roleService.AssignRoleAsync(id, requestList);
            return RedirectToAction("UserList","Admin");//random yazdım. değişebilir burası
        }

        public async Task<IActionResult> RoleUpdate(Guid id)
        {
            var (isSuccess, role) = await _roleService.FindByIdReturnRoleUpdateViewModelAsync(id);

            if (!isSuccess)
            {
                throw new Exception("Güncellenecek rol bulunamamıştır.");
            }
            return View(role);
        }
        [HttpPost]
        public async Task<IActionResult> RoleUpdate(RoleUpdateViewModel request)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var (isSuccess, error)=await _roleService.UpdateRoleAsync(request);

            if (!isSuccess)
            {
                foreach (var item in error!)
                {
                    ModelState.AddModelError("", item.Description);
                }
                return View();
            }
            else { TempData["success"]="Role güncelleme işlemi başarıyla yapıldı"; }
            return RedirectToAction(nameof(RoleController.RoleList));
        }
        public async Task<IActionResult> RoleDelete(Guid id)
        {
            var (isSuccess, error) = await  _roleService.DeleteRoleAsync(id);

            if (!isSuccess)
            {
                foreach (var item in error!)
                {
                    ModelState.AddModelError("", item.Description);
                }
                return View();
            }
            else { TempData["success"]="Rol başarıyla silinmiştir"; }
            return RedirectToAction(nameof(RoleController.RoleList));
        }

    }
}
