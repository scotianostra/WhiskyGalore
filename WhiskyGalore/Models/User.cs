using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Configuration;
using WhiskyGalore.Libs;
using System.Diagnostics;
using System.ComponentModel;
using System.Data;

namespace WhiskyGalore.Models
{
    public class User
    {
        public enum AccountType
        {
            Personal = 1,
            Business
        }

        [DisplayName("Username*")]
        public string username{ get; set; }
        [DisplayName("Password*")]
        public string password { get; set; }
        [DisplayName("E-Mail*")]
        public string email { get; set; }
        [DisplayName("Type of Account*")]
        public AccountType accountType { get; set; }


        private String con_str = ConfigurationManager.ConnectionStrings["MySQLConnection"].ConnectionString.ToString();

        public void registerUser(User user)
        {
            using (MySqlConnection con = new MySqlConnection(con_str))
            {
               
                con.Open();
                using (MySqlCommand cmd = new MySqlCommand("registerUser", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@username", user.username);
                    cmd.Parameters.AddWithValue("@password", Encryption.Encrypt(user.password));
                    cmd.Parameters.AddWithValue("@accountType", user.accountType);

                    cmd.ExecuteNonQuery();

                    con.Close();
                }
            }
        }
                    
               
            
        }

    }
    
