using System;
namespace HashtagManager.Models
{
    public class PostDto
    {
		public Guid Id { get; set; }
		public DateTime DatePost { get; set; }
		public string TextPost { get; set; }
		public Guid UserId { get; set; }
		public virtual UserDTO User { get; set; }
	}
}
