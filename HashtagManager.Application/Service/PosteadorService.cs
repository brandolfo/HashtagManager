using HashtagManager.Application.Service.Interface;
using HashtagManager.Domain.Entities.Model;
using HashtagManager.Domain.Context;
using System;
using System.Linq;
using System.Collections.Generic;

namespace HashtagManager.Application.Service
{
	public class PosteadorService : IBaseService<Posteador>
	{
		private readonly IHashTagContext _context;

		public PosteadorService(IHashTagContext context)
		{
			_context = context;
		}
		public Posteador Add(Posteador entity)
		{
			_context.Posts.Add(entity);
			return entity;
		}
		public void Delete(Guid entity)
		{
			var toDelete = _context.Posts.Find(entity);
			if (toDelete != null) _context.Posts.Remove(toDelete);
		}

		public IQueryable<Posteador> GetAll()
		{
			return _context.Posts.OrderByDescending(x => x.DatePost);
		}
		public IEnumerable<Posteador> GetQuery(Func<Posteador, bool> expression)
		{
			return _context.Posts.Where(expression);
		}

		public void Save()
		{
			_context.SaveChanges();
		}

		public Posteador Update(Guid entity, string body)
		{
			var postUpdate = _context.Posts.Find(entity);
			postUpdate.TextPost = body;
			return postUpdate;
		}

		public Posteador GetOne(Guid entity)
		{
			return _context.Posts.Find(entity);
		}

		public IEnumerable<Posteador> GetPosts(Guid entity)
		{
			throw new NotImplementedException();
			
		}
	}

}
