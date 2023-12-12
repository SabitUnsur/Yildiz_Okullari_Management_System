using Business.Abstract;
using Business.Constants;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;

namespace UI.Controllers
{
	public class TestController : Controller
	{
		IScheduledTaskService scheduledTaskService;
		IPersonService personService;

        public TestController(IPersonService personService, IScheduledTaskService scheduledTaskService)
        {
            this.personService = personService;
            this.scheduledTaskService = scheduledTaskService;
        }

        public  IActionResult Index()
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
        }
    }
}
