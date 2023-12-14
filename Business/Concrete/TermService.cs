using Business.Abstract;
using Business.Constants;
using Core.Exceptions;
using Core.UnitOfWorks;
using DataAccess.Abstract;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class TermService : ITermService
    {
        ITermBatchRepository _termDal ;
        IUnitOfWork _unitOfWork;

        public TermService(ITermBatchRepository termDal, IUnitOfWork unitOfWork)
        {
            _termDal = termDal;
            _unitOfWork = unitOfWork;
        }

        public async Task Add(Term entity)
        {
          await _termDal.Add(entity);
            _unitOfWork.CommitAsync();
        }

        public Term CheckAndAddNewTerm()
        {
           return  _termDal.CheckAndAddNewTerm();
        }

        public void Delete(Term entity)
        {
           _termDal.Delete(entity);
            _unitOfWork.Commit();
        }

        public IEnumerable<Term> GetAll()
        {
            return _termDal.GetAll();
        }

        public IEnumerable<Term> GetAll(Expression<Func<Term, bool>> filter)
        {
            return _termDal.GetAll(filter);
        }

        public Term GetById(Guid id)
        {
            var term = _termDal.GetById(id);
            if (term == null)
            {
                throw new Exception("Hata");
            }
            return term;
        }

        public void Update(Term entity)
        {
           _termDal.Update(entity);
            _unitOfWork.Commit();
        }
    }
}
