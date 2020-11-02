using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace HashtagManager.Models
{
	public class PostContext : DbContext
	{
		private readonly IConfiguration _config;
		public PostContext(IConfiguration config)
		{
			_config = config;
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(_config.GetConnectionString("Hashdb"));
		}

		public DbSet<Post> Posts { get; set; }
	}
}
