using System;
using System.Collections.Generic;

namespace HashtagManager.Models
{
	public interface IUser
	{
		Guid Id { get; set; }
		string Mail { get; set; }
		string Password { get; set; }
		List<Post> PostList { get; set; }
	}
}