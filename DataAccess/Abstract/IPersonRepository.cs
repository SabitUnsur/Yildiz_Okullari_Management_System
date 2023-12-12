using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
	public interface IPersonRepository:IGenericRepository<Person>
	{
		Task<List<Person>> GetAbsencesByDateRange(DateTime startDate, DateTime endDate);
		public int TotalAbsencesDayCountByStudentNumber(int studentNumber);
		Task<List<Attendance>> TotalAbsencesDayListByStudentNumber(int studentNumber);
		public DateTime? GetAbsenceDateForStudent(Person student, DateTime targetDate);
		DateTime? GetTodaysAbsenceDateForStudent(Guid studentId);
		List<Person> GetPersonsWithAttendances();
		Person GetPersonWithFamilyInfoById(Guid studentId);
    }
}
