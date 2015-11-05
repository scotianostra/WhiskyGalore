using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Configuration;
using WhiskyGalore.Libs;

namespace WhiskyGaloreAdmin.Models
{
    public class User
    {
        public enum AccountType
        {
            Administrator = 1,
            Manager,
            Retailer,
            Consumer,
            Warehouse
        }

        public string username { get; set; }
        public string password { get; set; }
        public int[] acntType { get; set; }
        public AccountType type { get; set; }
        private String con_str = ConfigurationManager.ConnectionStrings["MySQLConnection"].ConnectionString;
        //private MySqlConnection connection;

        public bool insert(string username, string password)
        {
            using (MySqlConnection cn = new MySqlConnection(con_str))
            {
                try
                {
                    // Here we already start using parameters in the query to prevent
                    // SQL injection.
                    string query = "insert into USERNAME (username, password) values (@username,@password);";
                    cn.Open();

                    using (MySqlCommand cmd = new MySqlCommand(query, cn))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@password", Encryption.Encrypt(password));
                        cmd.ExecuteNonQuery();
                    }
                    return true;
                }
                catch (MySqlException)
                {
                    return false;
                }
            }
        }

    }
}