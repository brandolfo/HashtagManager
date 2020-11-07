using System;
using System.Collections.Generic;
using System.Text;

namespace HashtagManager.Domain.Entities.Model
{
    public class User
    {
        public Guid Id { get; set; }
        public string Mail { get; set; }
        public List<Post> PostList { get; set; } = new List<Post>();
        public string Password { get; set; }
    }
}
