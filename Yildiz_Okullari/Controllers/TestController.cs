using Business.Abstract;
using Business.Constants;
using Microsoft.AspNetCore.Mvc;

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

        public async Task<IActionResult> Index()
        {
            var attendanceList = await personService.TotalAbsencesDayListByStudentNumber(653);
            return View(attendanceList);
        }
    }
}
