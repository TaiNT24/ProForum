﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.IO;

namespace WebApplication1.Models
{
    public class Account
    {
        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string Username { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 6)]
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
        ArticleDBContext context = null;
        String connStr = ConfigurationManager.ConnectionStrings["Proforum"].ConnectionString;
        public ListAccount()
        {
            context = new ArticleDBContext();
        }
        public string checkLogin(string username, string password, RoleAccount roleStr)
        {
            SqlConnection conn = new SqlConnection(connStr);

            String sqlQuery = "select FullName, Status from UserAccount " +
                "where Username = @username and Password= @password and Role=@role";


            SqlCommand command = new SqlCommand(sqlQuery, conn);


            if (roleStr.ToString().Equals("Admin"))
            {
                command.Parameters.AddWithValue("@role", 1);
            }
            else
            {
                command.Parameters.AddWithValue("@role", 0);
            }


            command.Parameters.AddWithValue("@username", username);
            command.Parameters.AddWithValue("@password", password);

            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }

            SqlDataReader dr = command.ExecuteReader(CommandBehavior.CloseConnection);
            if (dr.HasRows)
            {
                dr.Read();

                string status = dr.GetString(1);
                if (status.Equals("Blocked"))
                {
                    return "UserBlocked";
                }
                else
                {
                    string fullname = dr.GetString(0);
                    return fullname;
                }

            }

            return null;
        }


        public bool RegisterNewAccount(Account account)
        {

            SqlConnection conn = new SqlConnection(connStr);

            String sqlQuery = "Insert into UserAccount values(@username,@password,@fullname,@status,@role)";

            SqlCommand command = new SqlCommand(sqlQuery, conn);
            command.Parameters.AddWithValue("@username", account.Username);
            command.Parameters.AddWithValue("@password", account.Password);
            command.Parameters.AddWithValue("@fullname", account.FullName);
            command.Parameters.AddWithValue("@status", "Active");
            command.Parameters.AddWithValue("@role", false);



            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }

            int row = command.ExecuteNonQuery();
            if (row > 0)
            {
                return true;
            }
            return false;
        }

        public List<Account> getListAccount()
        {
            String sqlQuery = "select Username,Fullname,Status from UserAccount where Role!=1 ";
            var list = context.Database.SqlQuery<Account>(sqlQuery).ToList();
            return list;
        }
        public bool BlockAccount(string user)
        {
            String sqlQuery = "Update UserAccount set Status='Blocked' where Username={0}";
            context.Database.ExecuteSqlCommand(sqlQuery, user);
            return true;
        }

        public bool getRole(string username)
        {
            SqlConnection conn = new SqlConnection(connStr);

            String sqlQuery = "select Role from UserAccount " +
                "where Username = @username";


            SqlCommand command = new SqlCommand(sqlQuery, conn);


            command.Parameters.AddWithValue("@username", username);

            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }

            SqlDataReader dr = command.ExecuteReader(CommandBehavior.CloseConnection);

            bool role = false;

            if (dr.HasRows)
            {
                dr.Read();

                role = dr.GetBoolean(0); // true: admin
            }
            return role;
        }



    }

    public class CommonUse
    {
        public static void WriteLogError(Exception ex)
        {
            StreamWriter sw = null;
            try
            {
                sw = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "\\LogFile.txt", true);
                sw.WriteLine(DateTime.Now.ToString("g") + ": " + ex.Source + "; " + ex.Message);
                sw.Flush();
                sw.Close();
            }
            catch
            {
                // ignored
            }
        }
        public static void WriteLogErrorStr(Exception ex)
        {
            StreamWriter sw = null;
            try
            {
                sw = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "\\LogFile.txt", true);
                sw.WriteLine(DateTime.Now.ToString("g") + ": " + ex.Source + "; " + ex.Message);
                sw.Flush();
                sw.Close();
            }
            catch
            {
                // ignored
            }
        }

    }

}