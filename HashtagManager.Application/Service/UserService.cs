using HashtagManager.Application.Service.Interface;
using HashtagManager.Domain.Context;
using HashtagManager.Domain.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HashtagManager.Application.Service
{
	public class UserService : IBaseService<User>
	{
		private readonly IHashTagContext _context;
		public UserService(IHashTagContext context)
		{
			_context = context;
		}
		public User Add(User entity)
		{
			_context.Users.Add(entity);
			return entity;
		}

		public void Delete(Guid entity)
		{
			var ToDelete = _context.Users.Find(entity);
			if (ToDelete != null) _context.Users.Remove(ToDelete);
		}

		public IQueryable<User> GetAll()
		{
			return _context.Users;
		}
		public User GetOne(Guid entity)
		{
			return _context.Users.Find(entity);
		}
		public IEnumerable<User> GetQuery(Func<User, bool> expression)
		{
			return _context.Users.Where(expression);
			
		}

		public void Save()
		{
			_context.SaveChanges();
		}

		public User Update(User entity)
		{
			throw new NotImplementedException();
		}
	}
}
