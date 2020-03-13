using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Configuration;

namespace WebApplication1.Models
{
    public class Account
    {
        [Required]
        [StringLength(20, MinimumLength =3)]
        public string Username { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 1)]
        public string Password { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string FullName { get; set; }

        public string Status { get; set; }

        public RoleAccount Role { get; set; }

    }
    public enum RoleAccount
    {
        User,
        Admin
    }

    public class ListAccount
    {

        String connStr = ConfigurationManager.ConnectionStrings["Proforum"].ConnectionString;

        public string checkLogin(string username , string password, RoleAccount roleStr)
        {
            SqlConnection conn = new SqlConnection(connStr);

            String sqlQueryUser = "select FullName, Status from UserAccount " +
                "where Username = @username and Password= @password";

            String sqlQueryAdmin = "select AdminName from AdminAccount " +
                "where AdminUsername = @username and AdminPassword= @password";

            SqlCommand command = new SqlCommand(sqlQueryUser, conn);
            if (roleStr.ToString().Equals("Admin"))
            {
                command = new SqlCommand(sqlQueryAdmin, conn);
            }
            
            
            command.Parameters.AddWithValue("@username", username);
            command.Parameters.AddWithValue("@password", password);

            if(conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }

            SqlDataReader dr = command.ExecuteReader(CommandBehavior.CloseConnection);
            if (dr.Read())
            {
                string fullname = dr.GetString(0);
                return fullname; 
            }

            return null;
        }


        public bool RegisterNewAccount(Account account)
        {
            SqlConnection conn = new SqlConnection(connStr);

            String sqlQuery = "Insert into Account values(@username,@password,@fullname,@status)";

            SqlCommand command = new SqlCommand(sqlQuery, conn);
            command.Parameters.AddWithValue("@username", account.Username);
            command.Parameters.AddWithValue("@password", account.Password);
            command.Parameters.AddWithValue("@fullname", account.FullName);
            command.Parameters.AddWithValue("@status", "Active");


            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }

            int row = command.ExecuteNonQuery();
            if (row>0)
            {
                return true;
            }
            return false;
        }
    }
}