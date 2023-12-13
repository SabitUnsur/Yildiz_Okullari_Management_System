using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities;
using Entities.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            if (existingAttendance != null)
            {
                throw new Exception("Öğrencinin bugüne ait devamsızlık bilgisi mevcut");
            }
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

        public Attendance TotalDailyAbsencesLectureHours(List<LectureHours> selectedLectures,Guid userId)
        {
            int totalLectureHours = selectedLectures.Count();

            var attendance = new Attendance
            {
                AttendanceTotalLectureHour = totalLectureHours,
                Date = DateTime.UtcNow,
                PersonId = userId,
            };

            return attendance;

        }
    }
}
