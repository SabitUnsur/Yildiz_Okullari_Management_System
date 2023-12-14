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
    public class EfTermBatchRepository : GenericRepository<Term>, ITermBatchRepository
    {
        public EfTermBatchRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }

        public Term CheckAndAddNewTerm()
        {
            DateTime currentDate = DateTime.Now;
            var firstTerm = _appDbContext.Terms.OrderBy(t => t.StartDate).FirstOrDefault();

            if (firstTerm != null && firstTerm.EndDate < currentDate)
            {
                AddNewTerm(firstTerm.Id, ref firstTerm);
            }

            return firstTerm;
        }

        private void AddNewTerm(Guid previousTermId, ref Term firstTerm)
        {
            var previousTerm = _appDbContext.Terms.Find(previousTermId);
            Term newTerm = null;
            var students = _appDbContext.Persons.Where(x => x.TermId == previousTermId).ToList();

            foreach (var student in students)
            {
                if (student.Grade < 12 && student.Grade != null)
                { 
                        newTerm = new Term
                        {
                            Id = Guid.NewGuid(),
                            StartDate = previousTerm.StartDate.AddYears(1),
                            EndDate = previousTerm.StartDate.AddYears(1)
                        };

                        student.TermId = newTerm.Id;
                        student.Attendances = Enumerable.Empty<Attendance>().ToList();
                        student.Term = newTerm;
                        _appDbContext.Add(newTerm);
                    
                    student.Grade++;
                }
                else if (student.Grade == 12 && student.TermId == previousTermId)
                {
                    // 12. sınıf öğrencilerinin termId'sini güncelleme
                    student.TermId = student.TermId;
                }
                else
                {
                    newTerm ??= new Term
                    {
                        Id = Guid.NewGuid(),
                        StartDate = previousTerm.StartDate.AddYears(1),
                        EndDate = previousTerm.StartDate.AddYears(1)
                    };
                }
            }

            _appDbContext.SaveChanges();

            firstTerm = _appDbContext.Terms.OrderBy(t => t.StartDate).FirstOrDefault(term => term.Id == previousTermId);
        }
    }
}
