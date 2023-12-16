using Entities;
using Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
	public interface IAttendanceRepository : IGenericRepository<Attendance>
	{
        Task AddAttendanceWithAutomaticType(Attendance entity);
        Attendance TotalDailyAbsencesLectureHours(List<LectureHours> selectedLectures, ExcuseType excuseType, Guid userId);
        Task<List<Attendance>> GetAttendanceForTerm(Guid termId, Guid studentId);
        Task<decimal> GetTotalAttendanceDayForStudent(Guid userId);
    }
}
