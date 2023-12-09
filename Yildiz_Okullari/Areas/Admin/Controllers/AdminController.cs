using Microsoft.AspNetCore.Mvc;

namespace UI.Areas.Admin.Controllers
{
	public class AdminController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
