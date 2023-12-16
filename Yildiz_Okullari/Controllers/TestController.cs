using Business.Abstract;
using Business.Concrete;
using Business.Constants;
using Entities;
using Entities.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;
using System.Security.Claims;

namespace UI.Controllers
{
    public class TestController : Controller
    {
        /*IScheduledTaskService scheduledTaskService;
		IPersonService personService;

        public TestController(IPersonService personService, IScheduledTaskService scheduledTaskService)
        {
            this.personService = personService;
            this.scheduledTaskService = scheduledTaskService;
        }*/

        /* public  IActionResult Index()
         {
             var students = personService.GetAll(); // Tüm öğrencileri al

             foreach (var student in students)
             {
                 var absenceDates = personService.GetTodaysAbsenceDateForStudent(student.Id); // Öğrencinin bugünkü devamsızlık tarihlerini al
                 if (absenceDates.HasValue && absenceDates.Value.Date == DateTime.Today)
                 {
                     // Eğer öğrencinin bugünkü devamsızlık tarihi varsa ve bugünün tarihiyle eşleşiyorsa, SMS gönderme işlemini yap
                      scheduledTaskService.ScheduleSms(student.Id);
                 }
             }

             return View();
         }*/

      /* IAttendanceService attendanceService;
        protected readonly UserManager<Person> _userManager;

        public TestController(IAttendanceService attendanceService, UserManager<Person> userManager)
        {
            this.attendanceService = attendanceService;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var lectures = Enum.GetValues(typeof(LectureHours));
            ViewBag.Lectures = lectures;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddAttendance(List<LectureHours> selectedLectures)
        {
            var user = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var userId = await _userManager.FindByIdAsync(user);
            var attendance = attendanceService.TotalDailyAbsencesLectureHours(selectedLectures, userId.Id);
            await attendanceService.Add(attendance);
            return RedirectToAction("Index");
        }*/


         ITermService _termService;

         public TestController(ITermService termService)
         {
             _termService = termService;
         }

         public IActionResult RunCheckAndAddNewTerm()
         {
             Term firstTerm = _termService.CheckAndAddNewTerm();

             if (firstTerm != null && firstTerm.EndDate < DateTime.Now)
             {
                 ViewBag.ShowButton = true;
             }
             else
             {
                 ViewBag.ShowButton = false;
             }

             return View();
         }


   
    }
}
