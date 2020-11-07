using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace HashtagManager.Models
{
	public class User
	{
		[JsonIgnore]
		public Guid Id { get; set; }
		public string Mail { get; set; }
		[JsonIgnore]
		public virtual IEnumerable<Posteador> PostList { get; set; }
		public string Password { get; set; }
	}
}
