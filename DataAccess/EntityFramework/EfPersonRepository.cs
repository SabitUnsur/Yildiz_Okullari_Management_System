using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Enums;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DataAccess.EntityFramework
{
    public class EfPersonRepository : GenericRepository<Person>, IPersonRepository
    {
        public EfPersonRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }

        public DateTime? GetAbsenceDateForStudent(Person student, DateTime targetDate) //SUCCESSFUL
        {
            var absence = _appDbContext.Attendances.FirstOrDefault(a => a.Date.Day == targetDate.Date.Day && a.PersonId == student.Id);
            return absence?.Date;
        }

        public async Task<List<Attendance>> GetAbsencesByTermRange(Guid termId,Guid userId)
        {
            var x = await _appDbContext.Attendances.Where(x=>x.PersonId == userId && x.TermId ==termId).ToListAsync();
            return x;
        }

        public DateTime? GetTodaysAbsenceDateForStudent(Guid studentId)
        {
            AppDbContext appDbContext = new AppDbContext();

            var today = DateTime.Today;
            var attendance = appDbContext.Attendances
                .Where(x => x.PersonId == studentId &&
                            x.Date.Year == today.Year &&
                            x.Date.Month == today.Month &&
                            x.Date.Day == today.Day)
                .FirstOrDefault();

            return attendance?.Date;
        }


        // Girilen ogrenci numarasina gore dönemdeki toplam devamsizlik sayisini getirir.
        public int TotalAbsencesDayCountByStudentNumber(int? studentNumber) //SUCCESSFUL
        {
            var latestTerm = EfTermBatchRepository.GetLatestTerm();
            var termId = latestTerm?.Id;
            var uniqueAbsentDatesCount = _appDbContext.Users
                .Where(p => p.StudentNumber == studentNumber && p.TermId == termId)
                .SelectMany(p => p.Attendances.Select(a => a.Date))
                .GroupBy(date => date.Date)
                .Select(group => group.Key)
                .Count();
            return uniqueAbsentDatesCount;
        }


        //Ogrenciye ait tum devamsizliklari tarih ile birlikte getirir.
        public async Task<List<Attendance>> TotalAbsencesDayListByStudentNumber(int? studentNumber) //SUCCESSFUL
        {
            var latestTerm = EfTermBatchRepository.GetLatestTerm();
            var termId = latestTerm?.Id;
            var attendances = await _appDbContext.Users
                .Where(p => p.StudentNumber == studentNumber)
                .SelectMany(p => p.Attendances.Where(x=>x.TermId == termId).Select(a => new Attendance
                {
                    Date = a.Date,
                    Person = p,
                    AttendanceType = a.AttendanceType,
                    AttendanceTotalLectureHour = a.AttendanceType == AttendanceType.TamGün ? null : a.AttendanceTotalLectureHour,
                    ExcuseType = a.ExcuseType,

                })).OrderBy(a => a.Date)
                .ToListAsync();

            if(attendances != null)
            {

                return attendances;
            }

            return Enumerable.Empty<Attendance>().ToList();
        }

        public List<Person> GetPersonsWithAttendances()
        {
            var latestTerm = EfTermBatchRepository.GetLatestTerm();
            var termId = latestTerm?.Id;
            return _appDbContext.Users.Include(p => p.Attendances).Where(x=>x.TermId==termId).ToList();
        }

        public Person GetPersonWithFamilyInfoById(Guid studentId)
        {
            return _appDbContext.Users.Include(p => p.FamilyInfo).FirstOrDefault(p => p.Id == studentId);
        }

        public decimal? GetExcusedAbsencesCount(int? studentNumber)
        {
            var latestTerm = EfTermBatchRepository.GetLatestTerm();
            var termId = latestTerm?.Id;
            var excusedAbsencesCount = _appDbContext.Users
                .Where(p => p.StudentNumber == studentNumber)
                .SelectMany(p => p.Attendances.Where(a => a.ExcuseType == ExcuseType.Özürlü && a.TermId == termId))
               .Sum(a => a.TotalAttendance);
            return excusedAbsencesCount;
        }

        public decimal? GetNonExcusedAbsencesCount(int? studentNumber)
        {
            var latestTerm = EfTermBatchRepository.GetLatestTerm();
            var termId = latestTerm?.Id;
            var nonExcusedAbsencesTotal = _appDbContext.Users
                .Where(p => p.StudentNumber == studentNumber)
                .SelectMany(p => p.Attendances.Where(a => a.ExcuseType == ExcuseType.Özürsüz && a.TermId == termId))
                .Sum(a => a.TotalAttendance);

            return nonExcusedAbsencesTotal;
        }

        public List<Person> GetStudentsBranchsStudentsList(Guid studentId)
        {
            var latestTerm = EfTermBatchRepository.GetLatestTerm();
            var termId = latestTerm?.Id;
            var student = _appDbContext.Users.FirstOrDefault(x => x.Id == studentId);
            if (student == null)
            {
                return new List<Person>();
            }

            var studentsInSameBranch = _appDbContext.Users
                .Where(x => x.Branch == student.Branch && x.Grade == student.Grade && x.TermId == termId)
                .ToList();

            return studentsInSameBranch;
        }

        public List<Person> GetStudentsByGradeAndBranch(int grade, string branch)
        {
            return _appDbContext.Users.Where(p => p.Grade == grade && p.Branch == branch).AsNoTracking().ToList();
        }

        
    }
}

