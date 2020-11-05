using System;
using System.Collections.Generic;

namespace HashtagManager.Models
{
	public class User
	{

		public Guid Id { get; set; }
		public string Mail { get; set; }
		public virtual IEnumerable<Post> PostList { get; set; }
		public string Password { get; set; }
	}
}
