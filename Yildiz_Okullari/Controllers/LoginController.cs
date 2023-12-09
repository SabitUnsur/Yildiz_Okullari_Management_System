using Business.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers
{
	public class LoginController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
		[HttpPost]
		public IActionResult GirisYap(string kullaniciAdi, string sifre)
		{
			if (kullaniciAdi == "ogrenci" && sifre == "123")
			{
				return RedirectToAction("Index", "Student");
			}
			else if(kullaniciAdi == "admin" && sifre == "1234")
			{
				return View("~/Areas/Admin/Views/Admin/Index.cshtml");
			}
			else
			{
				ViewBag.HataMesaji = "Geçersiz kullanıcı adı veya şifre";
				return View("Index");
			}
		}
	}
}
