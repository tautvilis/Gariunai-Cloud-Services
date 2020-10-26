using System;
using System.IO;
using Microsoft.EntityFrameworkCore;

namespace Gariunai_Cloud_Services.Entities
{
    class DataAccess : DbContext
    {
        public DbSet<Shop> Businesses { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Produce> Produce { get; set; }
        public DbSet<Password> Passwords { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            //TODO find better solution
            string projectDir = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\.."));
            options.UseSqlServer(connectionString: $"Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"{projectDir}\\Backend\\Database\\GariunaiCloudDB.mdf\";Integrated Security=True");
        }
          
    }
}
