using System;
using System.Collections.Generic;

namespace HashtagManager.Models
{
	public class UserDTO
	{
		public Guid Id { get; set; }
		public string Mail { get; set; }
		public virtual IEnumerable<PostDTO> PostList { get; set; } = new List<PostDTO>();
	}
}
