using Business.Abstract;
using DataAccess;
using Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Security.Claims;

namespace UI.Controllers
{
    public class StudentController : StudentBaseController
    {
        private readonly IAttendanceService attendanceService;
        public StudentController(UserManager<Person> userManager, IPersonService service, IAttendanceService attendanceService) : base(userManager, service)
        {
            this.attendanceService = attendanceService;
        }

        public async Task<IActionResult> Index()
        {
            var user = await GetUser();
            var value = GetUserInfos(user);
            return View(value);
        }

        public async Task<IActionResult> UserInformationAsync()
        {
            var user = await GetUser();
            var values = _personService.GetPersonWithFamilyInfoById(user.Id);
            ViewBag.UserInformations = GetUserInfos(user);
            return View(values);
        }

        public async Task<IActionResult> TotalAbsencesDayList()
        {
            var user = await GetUser();
            var attendances = await attendanceService.GetTotalAttendanceDayForStudent(user.Id);
            TempData["AttendancesCount"] = attendances.ToString();
            TempData["ExcusedAttendancesCount"] =  _personService.GetExcusedAbsencesCount(user.StudentNumber).ToString();
            TempData["NonExcusedAttendancesCount"] =  _personService.GetNonExcusedAbsencesCount(user.StudentNumber).ToString();
            var values = await _personService.TotalAbsencesDayListByStudentNumber(user.StudentNumber);
            ViewBag.UserInformations = GetUserInfos(user);
            return View(values);
        }

        public async Task<IActionResult> GetStudentsBranchsStudentsList()
        {
            var user = await GetUser();
            TempData["StudentsClass"] = user.Grade.ToString();
            TempData["StudentsBranch"] = user.Branch.ToString();
            var values = _personService.GetStudentsBranchsStudentsList(user.Id);
            ViewBag.UserInformations = GetUserInfos(user);
            return View(values);
        }
        
    }
}
