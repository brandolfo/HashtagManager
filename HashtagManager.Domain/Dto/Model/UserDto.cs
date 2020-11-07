using HashtagManager.Domain.Entities.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace HashtagManager.Domain.Dto.Model
{
    class UserDto
    {
        public Guid Id { get; set; }
        public string Mail { get; set; }
        public List<Post> PostList { get; set; } = new List<Post>();
    }
}
