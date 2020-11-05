using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace HashtagManager.Models
{
	public class UserDTO
	{
		public Guid Id { get; set; }
		public string Mail { get; set; }
		public virtual IEnumerable<PostDto> PostList { get; set; } = new List<PostDto>();
	}
}
