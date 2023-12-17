using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
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
            var students = _appDbContext.Users.Where(x => x.TermId == previousTermId).ToList();
            var admins = from ur in _appDbContext.UserRoles
                         join p in _appDbContext.Persons on ur.UserId equals p.Id
                         where ur.RoleId == Guid.Parse("721417b8-b7d2-4e12-b0c6-b647c5b1a592")
                         select p;

            newTerm = new Term
            {
                Id = Guid.NewGuid(),
                StartDate = previousTerm.StartDate.AddYears(1),
                EndDate = previousTerm.EndDate.AddYears(1)
            };

            foreach (var student in students)
            {
                if (student.Grade < 12 && student.Grade != null)
                {
                    student.TermId = newTerm.Id;
                    student.Attendances = Enumerable.Empty<Attendance>().ToList();
                    student.Term = newTerm;
                    student.Grade++;
                }
                else if (student.Grade == 12 && student.TermId == previousTermId)
                {
                    student.TermId = student.TermId;
                }
            }
            foreach (var admin in admins)
            {
                admin.Term = newTerm;
            }
            _appDbContext.Add(newTerm);

            _appDbContext.SaveChanges();
        }

        public static Term? GetLatestTerm()
        {
            using (AppDbContext appDbContext = new AppDbContext())
            {
                Term latestTerm = appDbContext.Terms.OrderByDescending(x => x.StartDate).FirstOrDefault();
                return latestTerm;
            }
        }

        public static Term GetSelectedTerm(DateTime startDate, DateTime endDate)
        {
            using (AppDbContext appDbContext = new AppDbContext())
            {
                Term selectedTerm = appDbContext.Terms.Where(x => x.StartDate.Year == startDate.Year || x.EndDate.Year == endDate.Year).FirstOrDefault();
                return selectedTerm;
            }
        }
    }

}

