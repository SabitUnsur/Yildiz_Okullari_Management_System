using DataAccess.Abstract;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
		 
	{
		protected AppDbContext _appDbContext;

		private readonly DbSet<T> _dbSet;

		public GenericRepository(AppDbContext appDbContext)
		{
			_appDbContext = appDbContext;
			_dbSet = _appDbContext.Set<T>();
		}


		public async Task Add(T entity)
		{
			await _dbSet.AddAsync(entity);
		}

		public void Delete(T entity)
		{
			_dbSet.Remove(entity);
		}

		public IEnumerable<T> GetAll()
		{
			return _dbSet.AsNoTracking().AsQueryable();
		}

		public IEnumerable<T> GetAll(Expression<Func<T, bool>> filter)
		{
			return _dbSet.AsNoTracking().Where(filter).ToList();
		}

        public T GetById(Guid id)
        {
            return  _dbSet.Find(id);
        }

        public void Update(T entity)
		{
			_dbSet.Update(entity);
		}
	}
}
