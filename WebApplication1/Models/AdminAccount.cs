using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{

    public class AdminAccount
    {
        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string Username { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 1)]
        public string Password { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 1)]
        public string FullName { get; set; }


    }

    public class ListAdminAccount
    {

        String connStr = ConfigurationManager.ConnectionStrings["Proforum"].ConnectionString;

        public string checkAdminLogin(string username, string password)
        {
            SqlConnection conn = new SqlConnection(connStr);

            String sqlQuery = "select AdminName from AdminAccount " +
                "where AdminUsername = @username and AdminPassword= @password";

            SqlCommand command = new SqlCommand(sqlQuery, conn);
            command.Parameters.AddWithValue("@username", username);
            command.Parameters.AddWithValue("@password", password);

            if (conn.State == ConnectionState.Closed)
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

    }
}