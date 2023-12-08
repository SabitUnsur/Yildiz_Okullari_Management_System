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

		// Girilen dd.mm.yy bilgisine gore devamsiz ogrenci listesini getirir.
		public async Task<List<Person>> GetAbsencesByDateRange(DateTime startDate, DateTime endDate)
		{
			return await _appDbContext.Persons.Include(x => x.Attendances)
			.Where(p => p.Attendances.Any(a => a.Date >= startDate && a.Date <= endDate))
			.ToListAsync();
		}

		// Girilen ogrenci numarasina gore toplam devamsizlik sayisini getirir.
		public int TotalAbsencesDayCountByStudentNumber(int studentNumber)
		{
			return _appDbContext.Attendances.Include(x => x.Person).Where(p => p.Equals(studentNumber)).Count();
		}


		//Ogrenciye ait tum devamsizliklari tarih ile birlikte getirir.
		public async Task<List<Attendance>> TotalAbsencesDayListByStudentNumber(int studentNumber)
		{
			return await _appDbContext.Persons
				.Where(p => p.StudentNumber == studentNumber)
				.SelectMany(p => p.Attendances.Select(a => new Attendance { Date = a.Date, Person = p }))
				.ToListAsync();
		}

	}
}
