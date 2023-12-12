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
		Task<List<Person>> GetAbsencesByDateRange(DateTime startDate, DateTime endDate);
		int TotalAbsencesDayCountByStudentNumber(int studentNumber);
		Task<List<Attendance>> TotalAbsencesDayListByStudentNumber(int studentNumber);
		DateTime? GetAbsenceDateForStudent(Person student, DateTime targetDate);
		DateTime? GetTodaysAbsenceDateForStudent(Guid studentId);
		List<Person> GetPersonsWithAttendances();
		Person GetPersonWithFamilyInfoById(Guid studentId);
    }
}
