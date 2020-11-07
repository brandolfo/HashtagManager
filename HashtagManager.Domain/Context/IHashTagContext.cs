using HashtagManager.Domain.Entities.Model;
using Microsoft.EntityFrameworkCore;

namespace HashtagManager.Domain.Context
{
	class IHashTagContext
	{
		DbSet<Posteador> Posts { get; set; }
		DbSet<User> Users { get; set; }

	}
}
