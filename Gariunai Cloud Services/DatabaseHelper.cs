using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Gariunai_Cloud_Services.Entities;
using System.Diagnostics;

namespace Gariunai_Cloud_Services
{
    class DatabaseHelper
    {
        public static DataTable ExecuteQuery(string query)
        {
            string directory = System.IO.Path.GetFullPath(@"..\..\..\"); //swich to SQLite ? because this feels like an ugly hack  
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"" + directory + "Database\\LocalDatabase.mdf\";Integrated Security=True";
            using (var connection = new SqlConnection(connectionString))
            using (var adapter = new SqlDataAdapter(query, connection))
            {
                DataTable result = new DataTable();
                adapter.Fill(result);
                return result;
            }
        }
        public static void ExecuteTransactQuery(string query) 
        {
            string directory = System.IO.Path.GetFullPath(@"..\..\..\"); //swich to SQLite ? because this feels like an ugly hack  
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"" + directory + "Database\\LocalDatabase.mdf\";Integrated Security=True";
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand(query, connection))
            {
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
        public static User GetUserById(int id)
        {
            User user = new User();

            var queryResult = ExecuteQuery("SELECT * FROM accounts WHERE id = " + id.ToString());
            if (queryResult.Rows.Count != 0)
            {
                user.Name = (string)queryResult.Rows[0].ItemArray[1];
                user.Email = (string)queryResult.Rows[0].ItemArray[2];

                //TODO handle NULLs
                user.Description = (string)queryResult.Rows[0].ItemArray[3];
            } else { 
                //TODO handle bad Ids
            }

            return user;
        }
        public static List<string> getProduceByShopId(int id)
        {
            List<string> produce = new List<string>();

            var queryResult = ExecuteQuery("SELECT p.product FROM shopproduce sp, products p WHERE sp.shop = " + id.ToString() + " AND sp.product = p.id");
            foreach (DataRow row in queryResult.Rows)
            {
                produce.Add((string) row.ItemArray[0]);
            }

            return produce;
        }
        public static List<Business> GetBusinesses()
        {
            List<Business> result = new List<Business>();

            var queryResult = ExecuteQuery("SELECT * FROM shops");
            foreach(DataRow row in queryResult.Rows)
            {
                Business business = new Business();

                int shopId = (int)row.ItemArray[0];
                int ownerId = (int)row.ItemArray[1];

                business.Owner = GetUserById(ownerId);
                business.Name = (string)row.ItemArray[2];
                business.Description = (string)row.ItemArray[3];
                business.Produce = getProduceByShopId(shopId);

                result.Add(business);
            }
            return result;
        }

        public static void AddAcountToDB(User account)
        {
            string query = 
            $@"
                INSERT INTO accounts
                VALUES ('{account.Name}', '{account.Email}', '{account.Description}')
            ";
            try
            {
                ExecuteTransactQuery(query);
            }
            catch (SqlException ex) 
            {
                if (ex.Number == 2601 || ex.Number == 2627)
                {
                    //TODO handle
                    Debug.WriteLine("Such user already exits");
                }
            }
            
        }
        public static void AddProductToDB(string product) 
        {
            string query =
            $@"
                INSERT INTO products
                VALUES ('{product}')
            ";
            try
            {
                ExecuteTransactQuery(query);
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2601 || ex.Number == 2627)
                {
                    //TODO handle
                    Debug.WriteLine("Such product already exits");
                }
            }
        }

        public static void AddProductToShop(string ShopName, string product) 
        {
            //add product to product list
            AddProductToDB(product);

            //Add product to shop
            string query = 
            $@"
                INSERT INTO shopproduce 
                VALUES 
                (
                    (SELECT id FROM shops WHERE shopname = '{ShopName}'),
                    (SELECT id FROM products WHERE product = '{product}')
                )
            ";
            try
            {
                ExecuteTransactQuery(query);
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2601 || ex.Number == 2627)
                {
                    //TODO handle
                    Debug.WriteLine("Shop already has this product");
                }
            }
        }
        public static void AddShopToDB(Business business) 
        {
            AddAcountToDB(business.Owner);
            string query =
            $@"
                INSERT INTO shops
                VALUES
                (
                    (SELECT id FROM accounts WHERE username = '{business.Owner.Name}'),
                    '{business.Name}',
                    '{business.Description}'
                )
            ";

            try
            {
                ExecuteQuery(query);
                foreach (var product in business.Produce) 
                {
                    AddProductToShop(business.Name, product);
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2601 || ex.Number == 2627)
                {
                    //TODO handle
                    Debug.WriteLine("Such shop already exits");
                }
            }

        }
    }
}
