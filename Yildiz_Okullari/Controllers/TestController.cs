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
            // ... your existing code ...
            var person = personService.GetById(Guid.Parse("fd575ebe-a1a2-4c1c-84df-ff695766f819"));
            DateTime myTargetDate = DateTime.Parse("2023-12-11 13:17:43.774");
            DateTime myTargetDate2 = DateTime.Parse("2023-12-12 00:17:43.774");

            // Get the list of dates asynchronously
            var absences = await personService.GetAbsencesByDateRange(myTargetDate, myTargetDate2);

            // Return the list to the view
            return View(absences);
        }
    }
}
