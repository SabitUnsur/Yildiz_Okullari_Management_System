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

        // Girilen dd.mm.yy bilgisine gore devamsiz ogrenci listesini getirir.
        public async Task<List<Person>> GetAbsencesByDateRange(DateTime startDate, DateTime endDate) //SUCCESSFUL
        {
            return await _appDbContext.Persons.Include(x => x.Attendances)
            .Where(p => p.Attendances.Any(a => a.Date >= startDate && a.Date <= endDate))
            .ToListAsync();
        }

        public DateTime? GetTodaysAbsenceDateForStudent(Guid studentId) //SUCCESSFUL
        {
            AppDbContext appDbContext = new AppDbContext();
            var person = appDbContext.Persons.Find(studentId);

            var attendance = appDbContext.Attendances
                .Where(x => x.PersonId == studentId)
                .Where(x => x.Date.Day == DateTime.Today.Day)
                .FirstOrDefault();
            return attendance?.Date;
        }


        // Girilen ogrenci numarasina gore toplam devamsizlik sayisini getirir.
        public int TotalAbsencesDayCountByStudentNumber(int? studentNumber) //SUCCESSFUL
        {
            var uniqueAbsentDatesCount = _appDbContext.Persons
            .Where(p => p.StudentNumber == studentNumber)
            .SelectMany(p => p.Attendances.Select(a => a.Date).Distinct())
            .Count();

            return uniqueAbsentDatesCount;
        }


        //Ogrenciye ait tum devamsizliklari tarih ile birlikte getirir.
        public async Task<List<Attendance>> TotalAbsencesDayListByStudentNumber(int? studentNumber) //SUCCESSFUL
        {
            return await _appDbContext.Persons
                .Where(p => p.StudentNumber == studentNumber)
                .SelectMany(p => p.Attendances.Select(a => new Attendance { Date = a.Date, Person = p }))
                .ToListAsync();
        }

        public List<Person> GetPersonsWithAttendances()
        {
            return _appDbContext.Persons.Include(p => p.Attendances).ToList();
        }

        public Person GetPersonWithFamilyInfoById(Guid studentId)
        {
            return _appDbContext.Persons.Include(p => p.FamilyInfo).FirstOrDefault(p => p.Id == studentId);
        }

    }
}

