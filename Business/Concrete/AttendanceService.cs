using Business.Abstract;
using Business.Constants;
using Core.Exceptions;
using Core.UnitOfWorks;
using DataAccess;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities;
using Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
	public class AttendanceService : IAttendanceService
	{
		IAttendanceRepository _attendanceDal;
		IUnitOfWork _unitOfWork;

		public AttendanceService(IAttendanceRepository attendanceDal, IUnitOfWork unitOfWork)
		{
			_attendanceDal = attendanceDal;
			_unitOfWork = unitOfWork;
		}

		public async Task Add(Attendance entity)
		{
			await _attendanceDal.AddAttendanceWithAutomaticType(entity);
			await _unitOfWork.CommitAsync();
		}


		public void Delete(Attendance entity)
		{
			_attendanceDal.Delete(entity);
			_unitOfWork.CommitAsync();
		}

		public IEnumerable<Attendance> GetAll()
		{
			return _attendanceDal.GetAll();
		}

		public IEnumerable<Attendance> GetAll(Expression<Func<Attendance, bool>> filter)
		{
			return _attendanceDal.GetAll(filter);
		}

        public async Task<List<Attendance>> GetAttendanceForTerm(Guid termId, Guid studentId)
        {
            return await _attendanceDal.GetAttendanceForTerm(termId, studentId);
        }

        public Attendance GetById(Guid id)
		{
			var attendance = _attendanceDal.GetById(id);
			if (attendance == null)
			{
				throw new NotFoundException(Messages.AttendanceNotFound);
			}
			return attendance;
		}

        public async Task<decimal> GetTotalAttendanceDayForStudent(Guid userId)
        {
            return await _attendanceDal.GetTotalAttendanceDayForStudent(userId);
        }

        public Attendance TotalDailyAbsencesLectureHours(List<LectureHours> selectedLectures, ExcuseType excuseType, Guid userId)
        {
			return _attendanceDal.TotalDailyAbsencesLectureHours(selectedLectures,excuseType,userId);
        }

        public void Update(Attendance entity)
		{
			_attendanceDal.Update(entity);
			_unitOfWork.Commit();
		}
	}
}
