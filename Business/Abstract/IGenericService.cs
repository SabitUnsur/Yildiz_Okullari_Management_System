using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
	public interface IGenericService<T>
	{
		IEnumerable<T> GetAll();
		IEnumerable<T> GetAll(Expression<Func<T, bool>> filter);
		Task Add(T entity);
		void Update(T entity);
		void Delete(T entity);
		T GetById(Guid id);
	}
}
