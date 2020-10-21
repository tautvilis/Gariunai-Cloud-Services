using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using Gariunai_Cloud_Services.Backend.Entities;
using Microsoft.EntityFrameworkCore;

namespace Gariunai_Cloud_Services.Backend
{
    internal class DatabaseHelper
    {
        private const int Saltsize = 20;

        private static byte[] CreateSalt()
        {
            var rng = new RNGCryptoServiceProvider();
            var buff = new byte[Saltsize];
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
        ///     Checks if user has been registered with given username
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
        ///     Checks if user exists and has a given password
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

            var hash = GenerateSaltedHash(password, passwordFromDb?.Salt);
            return hash.SequenceEqual(passwordFromDb.Hash);
        }

        /// <summary>
        ///     Get all shops in database
        /// </summary>
        /// <returns>List of Shop objects</returns>
        public static List<Shop> GetBusinesses()
        {
            var db = new DataAccess();
            return db.Businesses
                .Include(b => b.Owner)
                .Include(b => b.Produce)
                .ToList();
        }

        /// <summary>
        ///     Adds new user to database
        /// </summary>
        /// <param name="user">User object, name field is required</param>
        /// <param name="password">user password</param>
        /// <returns>True if registration was successfull</returns>
        public static bool RegisterUser(User user, string password)
        {
            if (user is null || string.IsNullOrEmpty(user.Name))
                throw new ArgumentNullException(nameof(user));

            if (string.IsNullOrEmpty(password))
                throw new ArgumentException($@"'{nameof(password)}' cannot be null or empty", nameof(password));

            if (CheckIfUsernameTaken(user.Name))
                return false;

            var db = new DataAccess();

            var salt = CreateSalt();
            var hash = GenerateSaltedHash(password, salt);

            db.Add(user);
            db.SaveChanges();

            var newUser = db.Users.FirstOrDefault(u => u.Name == user.Name);
            var userPassword = new Password {Hash = hash, UserId = newUser.Id, Salt = salt};

            db.Add(userPassword);
            db.SaveChanges();
            return true;
        }

        /// <summary>
        ///     Adds new shop to database
        /// </summary>
        /// <param name="shop">Shop object name must be unuque</param>
        /// <param name="ownerName">Owner name, should be a registered user</param>
        /// <returns>True if registration was successful</returns>
        public static bool RegisterShop(Shop shop, string ownerName)
        {
            var db = new DataAccess();

            if (db.Businesses.Count(s => s.Name == shop.Name) > 0)
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
        ///     Gets user by name from database
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
        ///     Gets user by its id
        /// </summary>
        /// <param name="id">users id</param>
        /// <returns>User object if user exsits otherwise null</returns>
        public static User GetUserById(int id)
        {
            var db = new DataAccess();
            var result =
                db.Users
                    .Include(u => u.Businesses)
                    .ThenInclude(b => b.Produce)
                    .FirstOrDefault(u => u.Id == id);
            return result;
        }
    }
}