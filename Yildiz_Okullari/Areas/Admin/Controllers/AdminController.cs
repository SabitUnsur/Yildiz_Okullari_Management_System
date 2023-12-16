using Business.Abstract;
using Business.Concrete;
using Core.ViewModels;
using Entities;
using Entities.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Twilio.Http;

namespace UI.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class AdminController : Controller
	{
		private readonly IRegisterService _registerService;
        private readonly IPersonService _personService;
        private readonly IAttendanceService _attendanceService;
        IScheduledTaskService _scheduledTaskService;

        public AdminController(IRegisterService registerService, IPersonService personService, IAttendanceService attendanceService, IScheduledTaskService scheduledTaskService)
        {
            _personService = personService;
            _registerService = registerService;
            _attendanceService = attendanceService;
            _scheduledTaskService = scheduledTaskService;
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
                ViewBag.genderList=_registerService.GetGenderSelectList();
                return View();
            }

            var (isSuccess, errors) = await _registerService.RegisterStudentAsync(request);

            if (!isSuccess)
            {
                foreach (var error in errors!)
                {
                    ModelState.AddModelError("", error.Description);
                }
                ViewBag.genderList=_registerService.GetGenderSelectList();
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
            var users = _personService.GetAllStudentWithPersonViewModel();
            return View(users);
        }
        public IActionResult StudentDetailsList(Guid id)
        {
            var user=_personService.GetPersonWithFamilyInfoById(id);
            var personDetailsViewModel=PersonDetailsViewModel.PersonToPersonDetailsViewModel(user);
            return View(personDetailsViewModel);
            
        }
        [HttpGet]
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
            var user=_personService.GetPersonWithFamilyInfoById(id);
            var personViewModel= PersonUpdateViewModel.PersonToPersonUpdateViewModel(user);
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


        [HttpGet]
        public IActionResult AddAttendance(Guid id)
        {
            ViewBag.Id = id;
            var lectures = Enum.GetValues(typeof(LectureHours)).Cast<LectureHours>();
            var excuseTypes = Enum.GetValues(typeof(ExcuseType)).Cast<ExcuseType>();
            ViewBag.Lectures = lectures;
            ViewBag.excuseTypes = excuseTypes;
            return View();
        }

       [HttpPost]
        public async Task<IActionResult> AddAttendance(List<LectureHours> selectedLectures,ExcuseType excuseType,Guid studentId)
        {
                var user = _personService.GetById(studentId);
                var attendance = _attendanceService.TotalDailyAbsencesLectureHours(selectedLectures, excuseType, user.Id);
                await _attendanceService.Add(attendance);

            return RedirectToAction("StudentList");
        }

        [HttpPost]
        public IActionResult SendSms()
        {
            var students = _personService.GetAll(); 

            foreach (var student in students)
            {
                var absenceDates =  _personService.GetTodaysAbsenceDateForStudent(student.Id); 
                if (absenceDates.HasValue && absenceDates.Value.Date == DateTime.Today)
                {
                    _scheduledTaskService.ScheduleSms(student.Id);
                }
            }

            return RedirectToAction("StudentList");
        }



    }
}
