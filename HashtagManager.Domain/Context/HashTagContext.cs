using HashtagManager.Domain.Entities.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace HashtagManager.Domain.Context
{
	public class HashTagContext : DbContext, IHashTagContext
	{
		private readonly IConfiguration _config;
		public HashTagContext(IConfiguration config)
		{
			_config = config;
		}
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(_config.GetConnectionString("Hashdb"));
		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Posteador>().HasOne(x => x.user).WithMany(x => x.PostList);
		}
		public DbSet<Posteador> Posts { get; set; }
		public DbSet<User> Users { get; set; }
	}
}
