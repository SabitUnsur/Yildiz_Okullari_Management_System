using Business.Abstract;
using Core.ViewModels;
using DataAccess.EntityFramework;
using Entities;
using Microsoft.AspNetCore.Mvc;
using System.Web.Helpers;
using System.Xml.Linq;
using Twilio.Types;
using UI.Models;

namespace UI.Areas.Admin.Controllers
{
    public class AdminBaseController : Controller
    {
        protected readonly IPersonService _personService;
        private readonly IAttendanceService _attendanceService;

        public AdminBaseController(IAttendanceService attendanceService, IPersonService personService)
        {
            _attendanceService = attendanceService;
            _personService = personService;
        }

        protected async Task<List<Attendance>> GetAttendanceWithPersonalInformations(Guid studentId)
        {
            var user = _personService.GetById(studentId);
            var attendances = await _attendanceService.GetTotalAttendanceDayForStudent(studentId);
            TempData["AttendancesCount"] = attendances.ToString();
            TempData["ExcusedAttendancesCount"] = _personService.GetExcusedAbsencesCount(user.StudentNumber).ToString();
            TempData["NonExcusedAttendancesCount"] = _personService.GetNonExcusedAbsencesCount(user.StudentNumber).ToString();
            var values = await _personService.TotalAbsencesDayListByStudentNumber(user.StudentNumber);
            ViewBag.UserInformations = await GetUserInfos(user);
            return values;
        }

        protected async Task<StudentViewModel> GetUserInfos(Person user)
        {
            return new StudentViewModel
            {
                Id = user.Id,
                Name = user.Name.ToString(),
                Surname = user.Surname.ToString(),
                StudentNumber = user.StudentNumber.ToString(),
                Grade = user.Grade.ToString(),
                Branch = user.Branch.ToString(),
                Term = LatestTerm(),
                Attendances = await _attendanceService.GetAttendanceForTerm(LatestTerm().Id, user.Id)
            };
        }

        protected Term LatestTerm()
        {
            var latestTerm = EfTermBatchRepository.GetLatestTerm();
            return latestTerm;
        }

    }
}
