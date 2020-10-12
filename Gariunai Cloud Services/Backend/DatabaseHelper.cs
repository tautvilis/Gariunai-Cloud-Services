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
        /// <summary>
        /// Return true if user with given username and password exists in a database
        /// </summary>
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

        /// <summary>
        /// Get all shops in a database
        /// </summary>
        /// <returns>A List of Shop objects</returns>
        public static List<Shop> GetBusinesses()
        {
            DataAccess db = new DataAccess();
            return db.Businesses
                .Include(b => b.Owner)
                .Include(b => b.Produce)
                .ToList();
        }

        /// <summary>
        /// Registers a new user
        /// </summary>
        /// <param name="user">User object name field is required</param>
        /// <param name="password">Users password</param>
        /// <returns>true if registration was successful</returns>
        public static bool RegisterUser(User user, string password)
        {
            if (user.Name == null)
            {
                //TODO more informative return or exception
                return false;            
            }
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

        /// <summary>
        /// Adds a new shop to the database
        /// </summary>
        /// <param name="shop">shop name, must be unique</param>
        /// <param name="ownerName">owners name, must be a registered user</param>
        /// <returns>True if registration was succsessfull</returns>
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

        /// <summary>
        /// Gets user by name from database
        /// </summary>
        /// <param name="name">User name</param>
        /// <returns>User object if user exsits otherwise null</returns>
        public static User GetUserByName(string name) 
        {
            DataAccess db = new DataAccess();
            User result = db.Users.FirstOrDefault(u => u.Name == name);
            return result;
        }

        /// <summary>
        /// Gets user by its id
        /// </summary>
        /// <param name="id">users id</param>
        /// <returns>User object if user exsits otherwise null</returns>
        public static User GetUserById(int id)
        {
            DataAccess db = new DataAccess();
            User result = db.Users.FirstOrDefault(u => u.Id == id);
            return result;
        }
    }
}
