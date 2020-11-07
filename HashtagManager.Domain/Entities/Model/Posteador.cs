﻿using System;
using System.Text.Json.Serialization;
namespace HashtagManager.Domain.Entities.Model
{
	public class Posteador
	{
		public Guid Id { get; set; }
		public DateTime DatePost { get; set; }
		public string TextPost { get; set; }
		public Guid UserId { get; set; } //foreing key
		public virtual User user { get; set; } //prop de navegacion
	}
}
