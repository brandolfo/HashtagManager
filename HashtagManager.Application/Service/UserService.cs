using HashtagManager.Application.Service.Interface;
using HashtagManager.Domain.Context;
using HashtagManager.Domain.Entities.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

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
			var usuarios = _context.Users;
			return usuarios;
		}
		public User GetOne(Guid entity)
		{
			return _context.Users.Include(x => x.PostList).FirstOrDefault(x => x.Id == entity);
		}

		public IEnumerable<User> GetPosts(Guid entity)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<User> GetQuery(Func<User, bool> expression)
		{
			return _context.Users.Where(expression);
			
		}

		public void Save()
		{
			_context.SaveChanges();
		}

		public User Update(Guid entity, string body)
		{
			var userUpdate = _context.Users.Find(entity);
			userUpdate.Password = body;
			return userUpdate;
		}


	}
}
