using HashtagManager.Domain.Entities.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace HashtagManager.Domain.Context
{
    public interface IHashtagContext
    {
        DbSet<Post> Posts { get; set; }
        DbSet<User> Users { get; set; }
    }
}
