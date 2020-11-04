using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Web.UI.MobileControls;
using System.Windows.Forms;
using Gariunai_Cloud_Services.Entities;
using Microsoft.EntityFrameworkCore;

namespace Gariunai_Cloud_Services
{
    internal class DatabaseHelper
    {
        private static int saltsize = 20;

        private static byte[] CreateSalt()
        {
            var rng = new RNGCryptoServiceProvider();
            var buff = new byte[saltsize];
            rng.GetBytes(buff);
            return buff;
        }

        private static byte[] GenerateSaltedHash(string plainText, byte[] salt)
        {
            HashAlgorithm algorithm = new SHA256Managed();

            var plainTextWithSaltBytes =
                new byte[plainText.Length + salt.Length];

            for (var i = 0; i < plainText.Length; i++) plainTextWithSaltBytes[i] = (byte) plainText[i];
            for (var i = 0; i < salt.Length; i++) plainTextWithSaltBytes[plainText.Length + i] = salt[i];

            return algorithm.ComputeHash(plainTextWithSaltBytes);
        }

        /// <summary>
        /// Checks if user has been registered with given username
        /// </summary>
        /// <param name="username">username</param>
        /// <returns>True if username is taken</returns>
        public static bool CheckIfUsernameTaken(string username)
        {
            var db = new DataAccess();
            if (db.Users.Count(u => u.Name == username) > 0)
                return true;
            return false;
        }

        /// <summary>
        /// Checks if user exists and has a given password
        /// </summary>
        /// <param name="username">username</param>
        /// <param name="password">users password</param>
        /// <returns>True if user exists</returns>
        public static bool CheckIfUserExists(string username, string password)
        {
            var db = new DataAccess();
            var user = db.Users.FirstOrDefault(u => u.Name == username);

            if (user == null) return false;

            var passwordFromDb = db.Passwords.FirstOrDefault(p => p.UserId == user.Id);
            Debug.WriteLine(user.Id);

            var hash = GenerateSaltedHash(password, passwordFromDb.Salt);
            return hash.SequenceEqual(passwordFromDb.Hash);
        }

        /// <summary>
        /// Get all shops in database
        /// </summary>
        /// <returns>List of Shop objects</returns>
        public static List<Shop> GetBusinesses()
        {
            var db = new DataAccess();
            return db.Shops
                .Include(b => b.Owner)
                .Include(b => b.Produce)
                .Include(b => b.Followers)
                .ToList();
        }

        /// <summary>
        /// Adds new user to database
        /// </summary>
        /// <param name="user">User object, name field is required</param>
        /// <param name="password">user password</param>
        /// <returns>True if registration was successfull</returns>
        public static bool RegisterUser(User user, string password)
        {
            if (user is null || string.IsNullOrEmpty(user.Name))
                throw new ArgumentNullException(nameof(user));

            if (string.IsNullOrEmpty(password))
                throw new ArgumentException($"'{nameof(password)}' cannot be null or empty", nameof(password));

            if (CheckIfUsernameTaken(user.Name))
                return false;

            var db = new DataAccess();

            var salt = CreateSalt();
            var hash = GenerateSaltedHash(password, salt);

            AddEntityToDb(user);

            var newUser = db.Users.FirstOrDefault(u => u.Name == user.Name);
            var userPassword = new Password {Hash = hash, UserId = newUser.Id, Salt = salt};

            AddEntityToDb(userPassword);
            
            return true;
        }

        /// <summary>
        /// Adds new shop to database
        /// </summary>
        /// <param name="shop">Shop object name must be unuque</param>
        /// <param name="ownerName">Owner name, should be a registered user</param>
        /// <returns>True if registration was successful</returns>
        public static bool RegisterShop(Shop shop, string ownerName)
        {
            var db = new DataAccess();

            if (db.Shops.Count(s => s.Name == shop.Name) > 0)
                //TODO throw exception or return something more informative
                return false;

            var owner = db.Users.FirstOrDefault(u => u.Name == ownerName);

            if (owner == null)
                //TODO throw exception or return something more informative
                return false;

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
            var db = new DataAccess();
            var result = db.Users.FirstOrDefault(u => u.Name == name);
            return result;
        }

        /// <summary>
        /// Gets user by its id
        /// </summary>
        /// <param name="id">users id</param>
        /// <returns>User object if user exsits otherwise null</returns>
        public static User GetUserById(int id)
        {
            var db = new DataAccess();
            var result =
                db.Users
                    .Include(u => u.Follow)
                    .Include(u => u.Businesses)
                    .ThenInclude(b => b.Produce)
                    .FirstOrDefault(u => u.Id == id);
            return result;
        }
        
        
        /// <summary>
        /// Get shops info by its id
        /// </summary>
        /// <param name="id">shop id</param>
        /// <returns>Shop object</returns>
        public static Shop GetShopById(int id)
        {
            return new DataAccess().Shops
                .Include(b => b.Owner)
                .Include(b => b.Produce)
                .Include(b => b.Followers)
                .FirstOrDefault(s => s.Id == id);
        }
        
        
        /// <summary>
        /// If user follows given shop - unfollows, otherwise - follows
        /// </summary>
        /// <param name="userId">users id</param>
        /// <param name="shopId">shops id</param>
        public static void ChangeFollowStatus(int userId, int shopId)
        {
            var db = new DataAccess();

            if (db.Users.Count(u => u.Id == userId) == 0)
            {
                throw new ArgumentException($"user with id : {userId} does not exist");
            }
            if (db.Shops.Count(s => s.Id == shopId) == 0)
            {
                throw new ArgumentException($"shop with id : {userId} does not exist");
            }
            
            var currentFollow = db.Follows.FirstOrDefault(f => f.UserId == userId && f.ShopId == shopId);

            if (currentFollow == null)
            {
                var newFollow = new Follow()
                {
                    UserId = userId,
                    ShopId = shopId,
                    CreatedTime = DateTime.Now
                };
                db.Follows.Add(newFollow);
            } 
            else
            {
                db.Follows.Remove(currentFollow);
            }
            db.SaveChanges();
        }
        public static int GetFollowers(Shop shop)
        {
            var db = new DataAccess();
            if (db.Shops.Count(s => s.Id == shop.Id) == 0)
            {
                throw new ArgumentException($"shop with id : {shop.Id} does not exist");
            }
            var followerCount = db.Follows.Count(f => f.ShopId == shop.Id);
            return followerCount;
        }

        public static List<Notification> GetNotifications(User user)
        {
            var shops = GetFollowedShops(user);
            var notifications = new List<Notification>();
            foreach (var s in shops.Where(s => s.Notifications != null))
            {
                notifications.AddRange(s.Notifications);
            }
            return notifications;
        }

        private static List<Shop> GetFollowedShops(User user)
        {
            var db = new DataAccess();
            var followsId = db.Follows.Where(n => n.UserId == user.Id ).Select(f => f.ShopId).ToList();
            var followedShops = db.Shops.Where(s => followsId.Contains(s.Id)).Include(s => s.Notifications).ToList();
            return followedShops;
            
        }

        /// <summary>
        /// Checks current follow status
        /// </summary>
        /// <param name="userId">users id</param>
        /// <param name="shopId">shops id</param>
        /// <returns>true if given user follows given shop </returns>
        public static bool GetFollowStatus(int userId, int shopId)
        {
            var db = new DataAccess();

            if (db.Users.Count(u => u.Id == userId) == 0)
            {
                throw new ArgumentException($"user with id : {userId} does not exist");
            }
            if (db.Shops.Count(s => s.Id == shopId) == 0)
            {
                throw new ArgumentException($"shop with id : {userId} does not exist");
            }
            
            var follow = db.Follows.FirstOrDefault(f => f.UserId == userId && f.ShopId == shopId);
            return follow != null;
        }

        public static void AddEntityToDb<T>(T entity)
        {
            var db = new DataAccess();
            db.Add(entity);
            db.SaveChanges();
        }
    }
}