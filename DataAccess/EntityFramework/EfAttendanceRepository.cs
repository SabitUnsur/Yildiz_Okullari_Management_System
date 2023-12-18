using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities;
using Entities.Enums;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.EntityFramework
{
    public class EfAttendanceRepository : GenericRepository<Attendance>, IAttendanceRepository
	{
		public EfAttendanceRepository(AppDbContext appDbContext) : base(appDbContext)
		{
		}

        public async Task AddAttendanceWithAutomaticType(Attendance entity)
        {
            var existingAttendance = await _appDbContext.Attendances
            .Where(a => a.Date.Date == entity.Date.Date && a.PersonId == entity.PersonId)
            .FirstOrDefaultAsync();

            /*if (existingAttendance != null)
            {
                throw new Exception("Öğrencinin bugüne ait devamsızlık bilgisi mevcut");
            }*/

            CalculateAttendanceType(entity);
           await base.Add(entity);
        }

        private void CalculateAttendanceType(Attendance entity)
        {
            if (entity.AttendanceTotalLectureHour >= 0 && entity.AttendanceTotalLectureHour <= 3)
            {
                entity.AttendanceType = (AttendanceType?)1; 
            }
            else if (entity.AttendanceTotalLectureHour >= 4 && entity.AttendanceTotalLectureHour <= 8)
            {
                entity.AttendanceType = (AttendanceType?)0; 
            }
        }


        public Attendance TotalDailyAbsencesLectureHours(List<LectureHours> selectedLectures,ExcuseType excuseType,Guid userId)
        {
            int totalLectureHours = selectedLectures.Count();
            var user = _appDbContext.Users.Find(userId);

            var attendance = new Attendance
            {
                AttendanceTotalLectureHour = totalLectureHours,
                Date = DateTime.Now,
                PersonId = userId,
                ExcuseType = excuseType,
                TermId = user.TermId,
            };

            return attendance;

        }

        public async Task<decimal> GetTotalAttendanceDayForStudent(Guid userId)
        {
            var latestTerm = EfTermBatchRepository.GetLatestTerm();
            var termId = latestTerm?.Id;
            var attendances = await _appDbContext.Attendances
                .Where(a => a.PersonId == userId && a.TermId == termId)
                .OrderByDescending(a => a.TotalAttendance)
                .ToListAsync();

            decimal ?totalAttendance = 0; 

            foreach (var attendance in attendances)
            {
                totalAttendance += attendance.TotalAttendance; 
            }

            return (decimal)totalAttendance; 
        }

        public async Task<List<Attendance>> GetAttendanceForTerm(Guid ?termId, Guid studentId)
        {
            var attendancesForTerm = await _appDbContext.Attendances
                .Where(a => a.TermId == termId && a.PersonId == studentId)
                .ToListAsync();
            if(attendancesForTerm == null)
            {
                return Enumerable.Empty<Attendance>().ToList();
            }

            return attendancesForTerm;
        }

    }
}
