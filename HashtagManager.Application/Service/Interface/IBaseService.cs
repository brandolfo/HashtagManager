
using HashtagManager.Domain.Repository;

namespace HashtagManager.Application.Service.Interface
{
	public interface IBaseService<T> : IBaseRepository<T> where T: class
	{
	}
}
