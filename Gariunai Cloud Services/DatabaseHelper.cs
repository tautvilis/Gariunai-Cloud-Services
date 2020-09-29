using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Gariunai_Cloud_Services.Entities;

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
    }
}
