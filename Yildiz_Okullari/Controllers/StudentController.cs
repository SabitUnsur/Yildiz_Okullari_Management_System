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
            return View(user);
        }

        public async Task<IActionResult> UserInformationAsync()
        {
            var user = await GetUser();
            var values = _personService.GetPersonWithFamilyInfoById(user.Id);
            TempData["StudentName"] = user.Name.ToString();
            TempData["StudentSurname"] = user.Surname.ToString();
            TempData["StudentNumber"] = user.StudentNumber.ToString();
            TempData["StudentGrade"] = user.Grade.ToString();
            TempData["StudentBranch"] = user.Branch.ToString();
            return View(values);
        }

        public async Task<IActionResult> TotalAbsencesDayList()
        {
            var user = await GetUser();
            var attendances = await attendanceService.GetTotalAttendanceDayForStudent(user.Id);
            TempData["AttendancesCount"] = attendances.ToString();
            TempData["ExcusedAttendancesCount"] = _personService.GetExcusedAbsencesCount(user.StudentNumber).ToString();
            TempData["NonExcusedAttendancesCount"] = _personService.GetNonExcusedAbsencesCount(user.StudentNumber).ToString();
            var values = await _personService.TotalAbsencesDayListByStudentNumber(user.StudentNumber);
            TempData["StudentName"] = user.Name.ToString();
            TempData["StudentSurname"] = user.Surname.ToString();
            TempData["StudentNumber"] = user.StudentNumber.ToString();
            TempData["StudentGrade"] = user.Grade.ToString();
            TempData["StudentBranch"] = user.Branch.ToString();
            return View(values);
        }

        public async Task<IActionResult> GetStudentsBranchsStudentsList()
        {
            var user = await GetUser();
            TempData["StudentsClass"] = user.Grade.ToString();
            TempData["StudentsBranch"] = user.Branch.ToString();
            var values = _personService.GetStudentsBranchsStudentsList(user.Id);
            TempData["StudentName"] = user.Name.ToString();
            TempData["StudentSurname"] = user.Surname.ToString();
            TempData["StudentNumber"] = user.StudentNumber.ToString();
            TempData["StudentGrade"] = user.Grade.ToString();
            TempData["StudentBranch"] = user.Branch.ToString();
            return View(values);
        }
        
    }
}
