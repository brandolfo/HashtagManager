using System;
using System.Collections.Generic;
using System.Linq;

namespace HashtagManager.Domain.Repository
{
	public interface IBaseRepository<T> where T: class
	{
		T Add(T entity);
		IQueryable<T> GetAll();
		IEnumerable<T> GetQuery(Func<T, bool> expression);
		void Delete(Guid entity);
		T Update(Guid entity, string body);
		void Save();
		T GetOne(Guid entity);
		IEnumerable<T> GetPosts(Guid id);
	}
}
