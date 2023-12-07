using Business.Abstract;
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

		public PersonService(IPersonRepository personDal,IUnitOfWork unitOfWork)
		{
			_personDal = personDal;
			_unitOfWork = unitOfWork;
		}

		public Task Add(Person entity)
		{
			_personDal.Add(entity);
			_unitOfWork.CommitAsync();
			return Task.CompletedTask;

		}

		public void Delete(Person entity)
		{
			throw new NotImplementedException();
		}

		public Task<List<Person>> GetAbsencesByDateRange(DateTime startDate, DateTime endDate)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<Person> GetAll()
		{
			throw new NotImplementedException();
		}

		public IEnumerable<Person> GetAll(Expression<Func<Person, bool>> filter)
		{
			throw new NotImplementedException();
		}

		public Person GetById(int id)
		{
			throw new NotImplementedException();
		}

		public int TotalAbsencesDayCountByStudentNumber(int studentNumber)
		{
			throw new NotImplementedException();
		}

		public Task<List<Attendance>> TotalAbsencesDayListByStudentNumber(int studentNumber)
		{
			throw new NotImplementedException();
		}

		public void Update(Person entity)
		{
			throw new NotImplementedException();
		}
	}
}