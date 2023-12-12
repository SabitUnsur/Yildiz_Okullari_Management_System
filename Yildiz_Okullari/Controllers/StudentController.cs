using Business.Abstract;
using DataAccess;
using Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace UI.Controllers
{
    public class StudentController : StudentBaseController
    {
        public StudentController(UserManager<Person> userManager, IPersonService service): base(userManager, service)
        {
        }

        public async Task<IActionResult> Index()
        {
            var user = await GetUser();
            return View(user);
        }

        public async Task<IActionResult> UserInformationAsync()
        {
            var user = await GetUser();
            var values = _personService.GetPersonWithFamilyInfoById(user.Id);
            return View(values);
        }

        public async Task<IActionResult> TotalAbsencesDayList()
        {
            var user = await GetUser();
            TempData["AttendancesCount"] = _personService.TotalAbsencesDayCountByStudentNumber(user.StudentNumber).ToString();
            var values = await _personService.TotalAbsencesDayListByStudentNumber(user.StudentNumber);
            return View(values);
        }


    }
}
