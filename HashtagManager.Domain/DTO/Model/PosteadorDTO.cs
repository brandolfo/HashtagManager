using System;
using System.Text.Json.Serialization;

namespace HashtagManager.Domain.DTO.Model
{
	public class PosteadorDTO
	{
		[JsonIgnore]
		public Guid Id { get; set; }
		[JsonIgnore]
		public DateTime DatePost { get; set; }
		public string TextPost { get; set; }
		public Guid UserId { get; set; } //foreing key
		[JsonIgnore]
		public virtual UserDTO User { get; set; } //prop de navegacion

	}
}
