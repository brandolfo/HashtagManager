using System;

namespace HashtagManager.Models
{
	public interface IPost
	{
		DateTime DatePost { get; set; }
		Guid Id { get; set; }
		Guid UserId { get; set; }
		string TextPost { get; set; }
	}
}