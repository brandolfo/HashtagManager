using System;
using System.Collections.Generic;
using System.Text;

namespace HashtagManager.Domain.Entities.Model
{
	public class Post
	{
		public DateTime DatePost { get; set; } = DateTime.Now;
		public string TextPost { get; set; }
		public Guid Id { get; set; }
		public Guid UserId { get; set; }

	}
}
