using HashtagManager.Application.Service.Interface;
using HashtagManager.Domain.Entities.Model;
using HashtagManager.Domain.Context;
using System;
using System.Linq;
using System.Collections;
using System.Linq.Expressions;
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
			throw new NotImplementedException();
		}

		public IQueryable<Posteador> GetAll()
		{
			throw new NotImplementedException(); 
		}

		public IEnumerable<Posteador> GetQuery(Expression<Func<bool, Posteador>> expression)
		{
			throw new NotImplementedException();
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
