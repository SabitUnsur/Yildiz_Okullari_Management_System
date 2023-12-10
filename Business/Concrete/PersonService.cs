using Business.Abstract;
using Business.Constants;
using Core.Exceptions;
using Core.UnitOfWorks;
using DataAccess.Abstract;
using Entities;
using System.Linq.Expressions;

namespace Business.Concrete
{
	public class PersonService : IPersonService
	{
		private readonly IPersonRepository _personDal;
		private readonly IUnitOfWork _unitOfWork;
		private readonly IScheduledTaskService _taskManager;

		public PersonService(IPersonRepository personDal,IUnitOfWork unitOfWork,IScheduledTaskService taskManager) 
		{
			_personDal = personDal;
			_unitOfWork = unitOfWork;
			_taskManager = taskManager;
		}

		public async Task Add(Person entity)
		{
			await _personDal.Add(entity);
			await _unitOfWork.CommitAsync();
		}

		public void Delete(Person entity)
		{
			_personDal.Delete(entity);
			_unitOfWork.CommitAsync();
		}

		public async Task<List<Person>> GetAbsencesByDateRange(DateTime startDate, DateTime endDate)
		{
			var absences =  await _personDal.GetAbsencesByDateRange(startDate,endDate);

			if(absences.Count == 0)
			{
				return (List<Person>)Enumerable.Empty<Person>();
			}

			return absences;
		}

		public IEnumerable<Person> GetAll()
		{
			return _personDal.GetAll();
		}

		public IEnumerable<Person> GetAll(Expression<Func<Person, bool>> filter)
		{
			return _personDal.GetAll(filter);
		}

		public Person GetById(int id)
		{
			var person = _personDal.GetById(id);
			if(person == null)
			{
				throw new NotFoundException(Messages.UserNotFound); 
			}
			return person;
		}

		public int TotalAbsencesDayCountByStudentNumber(int studentNumber)
		{
			return _personDal.TotalAbsencesDayCountByStudentNumber(studentNumber);
		}

		public async Task<List<Attendance>>  TotalAbsencesDayListByStudentNumber(int studentNumber)
		{
			var DayList = await _personDal.TotalAbsencesDayListByStudentNumber(studentNumber) ;
			if(DayList.Count == 0)
			{
				return (List<Attendance>)Enumerable.Empty<Attendance>();
			}
			return DayList;
		}

		public void Update(Person entity)
		{
			_personDal.Update(entity);
			_unitOfWork.Commit();
		}
	}
}