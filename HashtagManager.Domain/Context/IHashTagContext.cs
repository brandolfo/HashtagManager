using HashtagManager.Domain.Entities.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace HashtagManager.Domain.Context
{
	public interface IHashTagContext
	{
		DbSet<Posteador> Posts { get; set; }
		DbSet<User> Users { get; set; }
	}
}
