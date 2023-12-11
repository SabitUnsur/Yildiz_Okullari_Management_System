using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities;
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
	}
}
