using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers
{
	public class RegisterController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
