using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Lab3.Models
{
    public class FriendModelDbContext : DbContext
    {
        public DbSet<FriendModel> Prijateli { get; set; }
        public static FriendModelDbContext Create()
        {
            return new FriendModelDbContext();
        }
    }
}