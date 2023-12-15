using Business.Abstract;
using Core.ViewModels;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Twilio.Http;

namespace UI.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class AdminController : Controller
	{
		private readonly IRegisterService _registerService;
        private readonly IPersonService _personService;
       
        public AdminController(IRegisterService registerService, IPersonService personService) 
        {
            _personService=personService;
            _registerService = registerService;
        }

        //Öğrenci kayıt işlemi
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

        //Admin kayıt işlemi
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

        public IActionResult StudentList() 
        {
            var users = _personService.GetAllWithPersonViewModel();
            return View(users);
        }
        public IActionResult StudentDetailsList(Guid id)
        {
            var user=_personService.GetById(id);
            var personDetailsViewModel=PersonDetailsViewModel.personToPersonDetailsViewModel(user);
            return View(personDetailsViewModel);
            
        }
        [Route("Admin/Admin/FilterStudentList")]
        public IActionResult FilterStudentList(string grade , string branch)
        {
            if(grade==null || branch==null)
            {
                ViewData["ErrorMessage"]="Lütfen sınıf ve şube seçiniz";
                return RedirectToAction(nameof(StudentList));
            }
            var users=_personService.GetStudentsByClassAndSectionWithPersonViewModel(Int32.Parse(grade),branch);
            return View(users);
        }
        public IActionResult DeleteStudent(Guid id)
        {
            var user=_personService.GetById(id);
            _personService.Delete(user);
            return RedirectToAction(nameof(StudentList));
        }
        public IActionResult EditStudent(Guid id)
        {
            var user=_personService.GetById(id);
            var personViewModel= PersonDetailsViewModel.personToPersonDetailsViewModel(user);
            return View(personViewModel);
        }
        [HttpPost]
        public IActionResult EditStudent(PersonUpdateViewModel person)
        {
            if(!ModelState.IsValid)
            {
                return View();
            }

            var user=_personService.UpdatePersonUpdateViewToPerson(person);
            _personService.Update(user);
            return RedirectToAction(nameof(StudentList));
        }
    }
}
