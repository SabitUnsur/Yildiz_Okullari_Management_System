using Business.Abstract;
using DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace UI.Controllers
{
	public class StudentController : Controller
	{
		IPersonService service;

        public StudentController(IPersonService service)
        {
            this.service = service;
        }

        public IActionResult Index()
		{
			var degerler = service.GetAll();
            return View(degerler);
		}

	}
}
