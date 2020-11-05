﻿using System;

namespace HashtagManager.Models
{
	public class Post
	{
		public Guid Id { get; set; }
		public DateTime DatePost { get; set; }
		public string TextPost { get; set; }
		public Guid UserId { get; set; }
		public virtual User User { get; set; }
	}
}
