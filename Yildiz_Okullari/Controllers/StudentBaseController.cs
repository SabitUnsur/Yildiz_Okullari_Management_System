using Business.Abstract;
using Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace UI.Controllers
{
    public class StudentBaseController : Controller
    {
        protected readonly UserManager<Person> _userManager;
        protected readonly IPersonService _personService;
       
        public StudentBaseController(UserManager<Person> userManager, IPersonService personService)
        {
            _userManager = userManager;
            _personService = personService;
        }

        protected async Task<Person> GetUser()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return await _userManager.FindByIdAsync(userId);
        }
    }
}
