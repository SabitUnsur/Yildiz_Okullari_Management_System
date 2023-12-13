using Business.Abstract;
using Core.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Win32;

namespace UI.Areas.Admin.Controllers
{
    
    [Area("Admin")]
    public class RegisterController : Controller
    {
        private readonly IRegisterService _registerService;

        public RegisterController(IRegisterService registerService)
        {
            _registerService = registerService;
        }

        public IActionResult RegisterAdmin()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RegisterAdmin(RegisterAdminViewModel request)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var (isSuccess, errors) = await _registerService.RegisterAdminAsync(request);

            if (!isSuccess)
            {
                foreach (var error in errors!)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View();
            }
            TempData["SuccessMessage"] = "Admin kayıt işlemi başarıyla tamamlanmıştır";

            return View(nameof(RegisterAdmin));
        }

        public IActionResult RegisterStudent()
        {
            ViewBag.genderList=_registerService.GetGenderSelectList();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RegisterStudent(RegisterStudentViewModel request)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var (isSuccess, errors) = await _registerService.RegisterStudentAsync(request);

            if (!isSuccess)
            {
                foreach (var error in errors!)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View();
            }
            TempData["SuccessMessage"] = "Öğrenci kayıt işlemi başarıyla tamamlanmıştır";

            return View(nameof(RegisterStudent));
        }
    }
}
