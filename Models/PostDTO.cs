using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HashtagManager.Models
{
	public class PostDTO
	{
		Guid Id { get; set; }
		public DateTime DatePost { get; set; }
		public string TextPost { get; set; }
		public Guid UserId { get; set; } //foreing key
		public virtual UserDTO User { get; set; } //prop de navegacion

	}
}
