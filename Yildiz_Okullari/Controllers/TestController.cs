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

        public IActionResult Index()
		{
			var person = personService.GetById(Guid.Parse("fd575ebe-a1a2-4c1c-84df-ff695766f819"));
			var task  = scheduledTaskService.ScheduleSms(person.Id);

			if (task.IsCompletedSuccessfully)
			{
                return RedirectToAction("Index", "Home");
            }
			return View();
		}
	}
}
