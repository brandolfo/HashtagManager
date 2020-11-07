using HashtagManager.Application.Service.Interface;
using HashtagManager.Domain.Context;
using HashtagManager.Domain.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace HashtagManager.Application.Service
{
    class PostService : IBaseService<Post>
    {
        private readonly IHashtagContext context;

        public PostService(IHashtagContext context)
        {
            this.context = context;
        }

        public Post Add(Post entity)
        {
            context.Posts.Add(entity);
            return entity;
        }

        public void Delete(Guid entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Post> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Post> GetQuery(Expression<Func<bool, Post>> expression)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public Post Update(Post entity)
        {
            throw new NotImplementedException();
        }
    }
}
