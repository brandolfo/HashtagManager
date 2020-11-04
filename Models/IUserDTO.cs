using System;
using System.Collections.Generic;

namespace HashtagManager.Models
{
	public interface IUserDTO
	{
		Guid Id { get; set; }
		string Mail { get; set; }
		List<Post> PostList { get; set; }
	}
}