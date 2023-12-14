using Entities;
using Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
	public interface IAttendanceService : IGenericService<Attendance>
	{
        Attendance TotalDailyAbsencesLectureHours(List<LectureHours> selectedLectures, Guid userId);
        Task<List<Attendance>> GetAttendanceForTerm(Guid termId, Guid studentId);
        Task<decimal> GetTotalAttendanceDayForStudent(Guid userId);
    }
}
