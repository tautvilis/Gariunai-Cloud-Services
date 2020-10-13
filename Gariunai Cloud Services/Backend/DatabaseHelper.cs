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
using System.Security.Cryptography;
using System.Windows.Forms;

namespace Gariunai_Cloud_Services
{
    class DatabaseHelper
    {
        private static int saltsize = 20;
        private static byte[] CreateSalt()
        {
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            byte[] buff = new byte[saltsize];
            rng.GetBytes(buff);
            return buff;
        }
        private static byte[] GenerateSaltedHash(string plainText, byte[] salt)
        {
            HashAlgorithm algorithm = new SHA256Managed();

            byte[] plainTextWithSaltBytes =
              new byte[plainText.Length + salt.Length];

            for (int i = 0; i < plainText.Length; i++)
            {
                plainTextWithSaltBytes[i] = (byte)plainText[i];
            }
            for (int i = 0; i < salt.Length; i++)
            {
                plainTextWithSaltBytes[plainText.Length + i] = salt[i];
            }

            return algorithm.ComputeHash(plainTextWithSaltBytes);
        }
        public static bool CheckIfUsernameTaken(string username)
        {
            DataAccess db = new DataAccess();
            if (db.Users.Count(u => u.Name == username) > 0)
                return true;
            else
                return false;
        }
        public static bool CheckIfUserExists(string username, string password)
        {

            DataAccess db = new DataAccess();
            var userCount = (from u in db.Users
                             join p in db.Passwords on u.Name equals p.UserName
                             where u.Name == username
                             select new { u, p }).Count();
            if (userCount == 0)
                return false;
            else
            {
                byte[] salt = (from u in db.Users
                            join p in db.Passwords on u.Name equals p.UserName
                            where u.Name == username
                            select p.Salt).First();
                var hash = GenerateSaltedHash(password, salt);
                var hashMatch = (from u in db.Users
                                 join p in db.Passwords on u.Name equals p.UserName
                                 where (u.Name == username) && (p.Hash == hash)
                                 select new { u, p }).Count();
                return hashMatch == 1;
            }
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
            if (user is null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            if (string.IsNullOrEmpty(password))
            {
                throw new ArgumentException($"'{nameof(password)}' cannot be null or empty", nameof(password));
            }
            DataAccess db = new DataAccess();
            var salt = CreateSalt();
            var hash = GenerateSaltedHash(password, salt);
            Password userPassword = new Password { Hash = hash, UserName = user.Name, Salt = salt };
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
