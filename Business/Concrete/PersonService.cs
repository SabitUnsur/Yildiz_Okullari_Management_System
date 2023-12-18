using Business.Abstract;
using Business.Constants;
using Core.Exceptions;
using Core.UnitOfWorks;
using Core.ViewModels;
using DataAccess.Abstract;
using DataAccess.EntityFramework;
using Entities;
using Microsoft.Extensions.Caching.Memory;
using System.Linq.Expressions;

namespace Business.Concrete
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personDal;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMemoryCache _memoryCache;

        public PersonService(IPersonRepository personDal, IUnitOfWork unitOfWork, IMemoryCache memoryCache)
        {
            _personDal = personDal;
            _unitOfWork = unitOfWork;
            _memoryCache = memoryCache;
        }

        public async Task Add(Person entity)
        {
            await _personDal.Add(entity);
            await _unitOfWork.CommitAsync();
            _memoryCache.Set(entity.Id, entity);
        }

        public void Delete(Person entity)
        {
            _memoryCache.Remove(entity.Id);
            _personDal.Delete(entity);
            _unitOfWork.CommitAsync();
        }

        public DateTime? GetAbsenceDateForStudent(Person student, DateTime targetDate)
        {

            string cacheKey = $"absence_{student.Id}_{targetDate:yyyy-MM-dd}";

            // Cache'den devamsızlık tarihini oku
            DateTime? absenceDate = _memoryCache.Get<DateTime?>(cacheKey);

            if (absenceDate == null)
            {
                absenceDate = _personDal.GetAbsenceDateForStudent(student, targetDate);
                _memoryCache.Set(cacheKey, absenceDate);
            }

            return absenceDate;
        }

        public async Task<List<Attendance>> GetAbsencesByTermRange(Guid termId, Guid userId)
        {
              var absences = await _personDal.GetAbsencesByTermRange(termId,userId);
                //_memoryCache.Set(cacheKey, absences);

            if (absences.Count == 0)
            {
                return Enumerable.Empty<Attendance>().ToList();
            }

            return absences;
        }

        public IEnumerable<Person> GetAll()
        {
            string cacheKey = "all_persons";
            List<Person> persons = _memoryCache.Get<List<Person>>(cacheKey);

            if (persons == null)
            {
                persons = _personDal.GetAll(x=>x.Name !="member").ToList();
                _memoryCache.Set(cacheKey, persons);
            }


            return persons;
        }

        public IEnumerable<Person> GetAll(Expression<Func<Person, bool>> filter)
        {
            string cacheKey = $"filtered_persons_{filter}";

            List<Person> persons = _memoryCache.Get<List<Person>>(cacheKey);

            if (persons == null)
            {
                persons = _personDal.GetAll(filter).ToList();
                _memoryCache.Set(cacheKey, persons);
            }

            return persons;
        }
        //Çağatay ekledi
        public List<PersonViewModel> GetAllStudentWithPersonViewModel()
        {
            var latestTerm = EfTermBatchRepository.GetLatestTerm();
            var termId = latestTerm?.Id;
            var persons = _personDal.GetAll(x=>x.Grade!=null && x.TermId == termId).ToList();

            List<PersonViewModel> personViewModels = new List<PersonViewModel>();
            foreach (Person person in persons)
            {
                personViewModels.Add(new PersonViewModel() { Id = person.Id, Branch = person.Branch, Grade = person.Grade, Name = person.Name, StudentNumber = person.StudentNumber, Surname = person.Surname });
            }
            return personViewModels;
        }

        public Person GetById(Guid id)
        {
            string cacheKey = $"person_{id}";

            Person person = _memoryCache.Get<Person>(cacheKey);

            if (person == null)
            {
                person = _personDal.GetById(id);

                if (person == null)
                {
                    throw new NotFoundException(Messages.UserNotFound);
                }
                _memoryCache.Set(cacheKey, person);
            }

            return person;
        }

        public decimal? GetExcusedAbsencesCount(int? studentNumber)
        {
            return _personDal.GetExcusedAbsencesCount(studentNumber);
        }

        public decimal? GetNonExcusedAbsencesCount(int? studentNumber)
        {
            return _personDal.GetNonExcusedAbsencesCount(studentNumber);
        }

        public List<Person> GetPersonsWithAttendances()
        {
            return _personDal.GetPersonsWithAttendances();
        }

        public Person GetPersonWithFamilyInfoById(Guid studentId)
        {
            return _personDal.GetPersonWithFamilyInfoById(studentId);
        }

        public List<Person> GetStudentsBranchsStudentsList(Guid studentId)
        {
            return _personDal.GetStudentsBranchsStudentsList(studentId);
        }

        // çağatay ekledi
        public List<PersonViewModel> GetStudentsByClassAndSectionWithPersonViewModel(int grade, string branch)
        {
            var list = _personDal.GetStudentsByGradeAndBranch(grade, branch);
            List<PersonViewModel> personViewModels = new List<PersonViewModel>();
            foreach (Person person in list)
            {
                personViewModels.Add(new PersonViewModel() { Id = person.Id, Branch = person.Branch, Grade = person.Grade, Name = person.Name, StudentNumber = person.StudentNumber, Surname = person.Surname });
            }
            return personViewModels;
        }

        public DateTime? GetTodaysAbsenceDateForStudent(Guid studentId)
        {
            string cacheKey = $"absence_student_{studentId}_{DateTime.Today}";

            DateTime? absenceDate = _memoryCache.Get<DateTime?>(cacheKey);

            if (absenceDate == null)
            {
                absenceDate = _personDal.GetTodaysAbsenceDateForStudent(studentId);
                _memoryCache.Set(cacheKey, absenceDate);
            }

            return absenceDate;
        }

        public int TotalAbsencesDayCountByStudentNumber(int? studentNumber)
        {
            string cacheKey = $"total_absences_{studentNumber}";

            int totalAbsenceCount = _memoryCache.Get<int>(cacheKey);

            if (totalAbsenceCount == 0)
            {
                totalAbsenceCount = _personDal.TotalAbsencesDayCountByStudentNumber(studentNumber);
                if (totalAbsenceCount > 0)
                {
                    _memoryCache.Set(cacheKey, totalAbsenceCount);
                }
            }

            return totalAbsenceCount;
        }

        public async Task<List<Attendance>> TotalAbsencesDayListByStudentNumber(int? studentNumber)
        {
            var attendanceList = await _personDal.TotalAbsencesDayListByStudentNumber(studentNumber);

            if (attendanceList.Count == 0)
            {
                return Enumerable.Empty<Attendance>().ToList();
            }
            return attendanceList;
        }

        public void Update(Person entity)
        {
            _personDal.Update(entity);
            _unitOfWork.Commit();
        }

        public Person UpdatePersonUpdateViewToPerson(PersonUpdateViewModel personUpdateViewModel)
        {
            var user = _personDal.GetPersonWithFamilyInfoById(personUpdateViewModel.Id);

            user.Name = personUpdateViewModel.Name;
            user.Surname = personUpdateViewModel.Surname;
            user.StudentNumber = personUpdateViewModel.StudentNumber;
            user.Grade = personUpdateViewModel.Grade;
            user.Branch = personUpdateViewModel.Branch;
            user.Email = personUpdateViewModel.Email;
            user.PhoneNumber = personUpdateViewModel.PhoneNumber;
            user.FamilyInfo!.MotherPhoneNumber = personUpdateViewModel.MotherNumber;
            user.FamilyInfo.FatherPhoneNumber = personUpdateViewModel.FatherNumber;
            user.FamilyInfo.MotherFullName = personUpdateViewModel.MotherFullName;
            user.FamilyInfo.FatherFullName = personUpdateViewModel.FatherFullName;

            return user;
        }
    }
}