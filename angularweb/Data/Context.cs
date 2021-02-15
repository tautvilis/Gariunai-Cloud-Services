using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.IO;
using angularweb.Entities;

namespace angularweb.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options)
            : base(options)
        {
        }


        public DbSet<User> Users { get; set; }

        public DbSet<Notification> Notifications { get; set; }

        public DbSet<Follow> Follows { get; set; }

        public DbSet<Password> Passwords { get; set; }

        public DbSet<Shop> Shops { get; set; }

        public DbSet<Produce> Produce { get; set; }

    }
}