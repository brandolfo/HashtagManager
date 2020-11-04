using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace HashtagManager.Models
{
	public class Context : DbContext
	{
		private readonly IConfiguration _config;
		public Context(IConfiguration config)
		{
			_config = config;
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(_config.GetConnectionString("Hashdb"));
		}

		public DbSet<Post> Posts { get; set; }
		public DbSet<User> Users { get; set; }
	}
}
