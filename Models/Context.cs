﻿using Microsoft.EntityFrameworkCore;
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

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Post>().HasOne(x => x.user).WithMany(x => x.PostList);
		}

		public DbSet<Post> Posts { get; set; }
		public DbSet<User> Users { get; set; }
	}
}
