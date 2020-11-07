using System;
using System.Collections.Generic;
using System.Text;

namespace HashtagManager.Domain.Dto.Model
{
    public class PostDto
	{
		public DateTime DatePost { get; set; }
		public string TextPost { get; set; }
		public Guid Id { get; set; }
		public Guid UserId { get; set; }
	}
}
