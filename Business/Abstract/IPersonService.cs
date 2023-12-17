using Core.ViewModels;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
	public interface IPersonService:IGenericService<Person>
	{
		Task<List<Attendance>> GetAbsencesByTermRange(Guid termId, Guid userId);
        int TotalAbsencesDayCountByStudentNumber(int ?studentNumber);
		Task<List<Attendance>> TotalAbsencesDayListByStudentNumber(int ?studentNumber);
		DateTime? GetAbsenceDateForStudent(Person student, DateTime targetDate);
		DateTime? GetTodaysAbsenceDateForStudent(Guid studentId);
		List<Person> GetPersonsWithAttendances();
		Person GetPersonWithFamilyInfoById(Guid studentId);
		List<PersonViewModel> GetAllStudentWithPersonViewModel();
		List<PersonViewModel> GetStudentsByClassAndSectionWithPersonViewModel(int grade, string branch);
        decimal? GetNonExcusedAbsencesCount(int? studentNumber);
        decimal? GetExcusedAbsencesCount(int? studentNumber);
        List<Person> GetStudentsBranchsStudentsList(Guid studentId);
        Person UpdatePersonUpdateViewToPerson(PersonUpdateViewModel personUpdateViewModel);
    }
}
