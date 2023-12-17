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
		Task<List<Attendance>> GetAbsencesByTermRange(Guid termId, Guid userId);
        public int TotalAbsencesDayCountByStudentNumber(int ?studentNumber);
		Task<List<Attendance>> TotalAbsencesDayListByStudentNumber(int ?studentNumber);
		public DateTime? GetAbsenceDateForStudent(Person student, DateTime targetDate);
		DateTime? GetTodaysAbsenceDateForStudent(Guid studentId);
		List<Person> GetPersonsWithAttendances();
		List<Person> GetStudentsBranchsStudentsList(Guid studentId);
        Person GetPersonWithFamilyInfoById(Guid studentId);
		List<Person> GetStudentsByGradeAndBranch(int grade, string branch);
		decimal? GetNonExcusedAbsencesCount(int? studentNumber);
		decimal? GetExcusedAbsencesCount(int? studentNumber);
    }
}
