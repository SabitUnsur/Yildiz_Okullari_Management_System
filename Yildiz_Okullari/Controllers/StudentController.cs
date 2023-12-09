using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers
{
	public class StudentController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}

	}
}
