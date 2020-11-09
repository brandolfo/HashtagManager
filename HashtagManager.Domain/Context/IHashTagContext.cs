using HashtagManager.Domain.Entities.Model;
using Microsoft.EntityFrameworkCore;

namespace HashtagManager.Domain.Context
{
	public interface IHashTagContext
	{
		DbSet<Posteador> Posts { get; set; }
		DbSet<User> Users { get; set; }
		int SaveChanges();
	}
}
