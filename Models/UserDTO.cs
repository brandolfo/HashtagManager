using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HashtagManager.Models
{
	public class UserDTO : IUserDTO
	{
		public Guid Id { get; set; }
		public string Mail { get; set; }
		public List<Post> PostList { get; set; } = new List<Post>();
	}
}
