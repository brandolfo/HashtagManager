using System;

namespace HashtagManager.Models
{
	public class Post : IPost
	{
		public DateTime DatePost { get; set; } = DateTime.Now;
		public string TextPost { get; set; }
		public Guid Id { get; set; }
		public Guid UserId { get; set; }

	}
}
