using Business.Abstract;
using Core.ViewModels;
using Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILoginService _loginService;
        private readonly IEmailService _emailService;
        private readonly UserManager<Person> _userManager;

        public LoginController(ILoginService loginService, IEmailService emailService, UserManager<Person> userManager)
        {
            _loginService=loginService;
            _emailService=emailService;
            _userManager=userManager;
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel request,string ? returnUrl = null)
        {
            if(!ModelState.IsValid)
            {
                return View();
            }

            returnUrl=returnUrl ?? Url.Action("Index", "Student");// bu kısım değişebilir random yazdım.

            var user= await _loginService.FindByEmailAsync(request.Email!);

            if (user==null)
            {
                ModelState.AddModelError("","Email veya şifre yanluş");
            }

            var result=await _loginService.LoginAsync(request,user!);

            if(result)
                return Redirect(returnUrl!);

            ModelState.AddModelError("","Email veya şifre yanlış");

            return View();

        }
        public IActionResult ForgetPassword()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ForgetPassword(ForgetPasswordViewModel request)
        {
            if(!ModelState.IsValid)
            {
                return View();
            }   
            var user=await _loginService.FindByEmailAsync(request.Email!);
            if(user==null)  
            {
                ModelState.AddModelError("","Bu email adresine sahip öğrenci bulunamamıştır.");
                return View();
            }

            //şifre değiştirmede kullanılacak tokenı ürettik.
            var passwordResetToken=await _loginService.GeneratePasswordResetTokenAsync(user.Id);

            //şifre değiştirme linki oluşturduk. şifre değiştirmek için token ve userid gerekli (user ı bulmak için). http://localhost:5000/Login/ResetPassword?token=token&userId=userid bunun gibi bişey olacak
            var passwordResetLink=Url.Action("ResetPassword","Login",new {token=passwordResetToken,userId=user.Id},HttpContext.Request.Scheme);

            // emaile link gönderme 
            await _emailService.SendResetPasswordLinkToEmailAsync(passwordResetLink!,user.Email!);

            TempData["success"]="Şifre yenileme linki e-posta adresinize gönderilmiştir.";

            return RedirectToAction(nameof(ForgetPassword));
        }
        //yukarda olusturduğumuz link ile token ve userid yi aldık.
        public IActionResult ResetPassword(string token,Guid userId)
        {
            // bunları tempdata ile tuttuk çünkü viewler arası veri taşımamız lazım bunlara ihtiyacımız var.
            //çünkü biz resetpassword un post kısmında bu token ve userid yi kullanacağız.
            TempData["token"]=token;
            TempData["userId"]=userId;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel request)
        {
            if(!ModelState.IsValid)
            {
                return View();
            }
            //tempdata ile tuttuğumuz token ve userid yi aldık.
            //tempdata ile gelen veriler object olarak geldiği için stringe çevirdik.
            var token = TempData["token"]?.ToString();
            var userId = TempData["userId"]?.ToString();

            if(token==null || userId==null)
            {
                ModelState.AddModelError("","Bir hata meydana geldi.Lütfen tekrar deneyiniz.");
                return View();
            }

            //token ve userid yi kullanarak user ı bulduk.
            var user=await _userManager.FindByIdAsync(userId);

            if(user==null)
            {
                ModelState.AddModelError("","Kullanıcı bulunamadı");
                return View();
            }

            //şifre değiştirme işlemi
            var result=await _userManager.ResetPasswordAsync(user,token!,request.Password!);

            if(!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("",error.Description);
                }
                return View();
            }

            TempData["success"]="Şifreniz başarıyla değiştirilmiştir.";

            return RedirectToAction(nameof(LoginController.ResetPassword));
        }   
    }
}
