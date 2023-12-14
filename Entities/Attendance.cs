using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Enums;

namespace Entities
{
    public class Attendance
	{
        public Guid Id { get; set; }
		public DateTime Date { get; set; }
		public int ?AttendanceTotalLectureHour { get; set; }
		public Guid PersonId { get; set; }
		public Person Person { get; set; }
        public decimal? TotalAttendance { get; set; }
        public AttendanceType ?AttendanceType { get; set; }
		public ExcuseType ?ExcuseType { get; set; }
		public Term Term { get; set; }
		public Guid ?TermId { get; set; }

    }
}
