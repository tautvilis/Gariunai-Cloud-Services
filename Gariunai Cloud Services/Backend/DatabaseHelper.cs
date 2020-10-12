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
using Microsoft.EntityFrameworkCore;

namespace Gariunai_Cloud_Services
{
    class DatabaseHelper
    {
        public static bool CheckIfUserExists(string username, string password)
        {
            DataAccess db = new DataAccess();
            string hash = password; //TODO hash
            var userCount = (from u in db.Users
                             join p in db.Passwords on u.Id equals p.UserId
                             where u.Name == username && p.Hash == hash
                             select new { u, p }).Count();
            return userCount != 0;
        }

        public static List<Shop> GetBusinesses()
        {
            DataAccess db = new DataAccess();
            return db.Businesses
                .Include(b => b.Owner)
                .Include(b => b.Produce)
                .ToList();
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
            db.Add(user);
            db.SaveChanges();

            User newUser = db.Users.FirstOrDefault(u => u.Name == user.Name);
            Password userPassword = new Password { Hash = password, UserId = newUser.Id};
            
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

        public static User GetUserByName(string name) 
        {
            DataAccess db = new DataAccess();
            User result = db.Users.FirstOrDefault(u => u.Name == name);
            return result;
        }

        public static User GetUserById(int id)
        {
            DataAccess db = new DataAccess();
            User result = db.Users.FirstOrDefault(u => u.Id == id);
            return result;
        }
    }
}
