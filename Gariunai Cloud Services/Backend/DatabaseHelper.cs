using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Gariunai_Cloud_Services.Entities;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace Gariunai_Cloud_Services
{
    class DatabaseHelper
    {
        public static bool CheckIfUserExists(string username, string password)
        {
            DataAccess db = new DataAccess();
            string hash = password; //TODO hash
            var userCount = (from u in db.Users
                             join p in db.Passwords on u.Name equals p.UserName
                             where u.Name == username && p.Hash == hash
                             select new { u, p }).Count();
            return userCount != 0;
        }

        public static List<Shop> GetBusinesses()
        {
            DataAccess db = new DataAccess();
            return db.Businesses.ToList();
        }

        public static bool RegisterUser(User user, string password)
        {
            DataAccess db = new DataAccess();
            if (db.Users.Count(u => u.Name == user.Name || u.Email == user.Email) > 0)
            {
                //todo throw exception or return something more informative
                return false;
            }

            //TODO hash
            Password userPassword = new Password { Hash = password, UserName = user.Name };
            db.Add(user);
            db.Add(userPassword);
            db.SaveChanges();
            return true;
        }

        public static bool RegisterShop(Shop shop, string ownerName)
        {
            DataAccess db = new DataAccess();

            if(db.Businesses.Count(s => s.Name == shop.Name) > 0) 
            {
                //TODO throw exception or return something more informative
                return false;
            }

            User owner = db.Users.FirstOrDefault(u => u.Name == ownerName);

            if(owner == null)
            {
                //TODO throw exception or return something more informative
                return false;
            }

            shop.Owner = owner;
            db.Add(shop);
            db.SaveChanges();
            return true;
        }
    }
}
