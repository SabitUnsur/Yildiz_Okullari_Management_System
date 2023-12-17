using Business.Abstract;
using Business.Concrete;
using Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using UI.Models;

namespace UI.Controllers
{
    public class StudentBaseController : Controller
    {
        protected readonly UserManager<Person> _userManager;
        protected readonly IPersonService _personService;
        protected readonly ITermService _termService;

        public StudentBaseController(UserManager<Person> userManager, IPersonService personService, ITermService termService)
        {
            _userManager = userManager;
            _personService = personService;
            _termService = termService;
        }

        protected async Task<Person> GetUser()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await _userManager.FindByIdAsync(userId);
            Guid termId = user.TermId.GetValueOrDefault(); 
            var term = _termService.GetById(termId);
            ViewBag.TermDate = term;
            return user;
        }

        protected StudentViewModel GetUserInfos(Person user)
        {
            return new StudentViewModel
            {
                Name = user.Name.ToString(),
                Surname = user.Surname.ToString(),
                StudentNumber = user.StudentNumber.ToString(),
                Grade = user.Grade.ToString(),
                Branch = user.Branch.ToString(),
            };
        }
    }
}
