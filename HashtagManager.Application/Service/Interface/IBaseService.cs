using HashtagManager.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace HashtagManager.Application.Service.Interface
{
    public interface IBaseService<T> :IBaseRepository<T> where T: class
    {
    }
}
