using HashtagManager.Application.Service.Interface;
using HashtagManager.Domain.Entities.Model;
using HashtagManager.Domain.Context;
using System;
using System.Linq;
using System.Collections.Generic;

namespace HashtagManager.Application.Service
{
	class PosteadorService : IBaseService<Posteador>
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
			_context.Posts.Remove(toDelete);
		}

		public IQueryable<Posteador> GetAll()
		{
			var allList = _context.Posts.OrderByDescending(x => x.DatePost);
			return allList;
		}
		public IEnumerable<Posteador> GetQuery(Func<Posteador, bool> expression)
		{
			return _context.Posts.Where(expression);
		}

		public void Save()
		{
			throw new NotImplementedException();
		}

		public Posteador Update(Posteador entity)
		{
			throw new NotImplementedException();
		}

	}

}
