using System;
using System.Collections.Generic;

namespace HashtagManager.Domain.DTO.Model
{
	public class UserDTO
	{
		public Guid Id { get; set; }
		public string Mail { get; set; }
		public virtual IEnumerable<PosteadorDTO> PostList { get; set; } = new List<PosteadorDTO>();
	}
}
