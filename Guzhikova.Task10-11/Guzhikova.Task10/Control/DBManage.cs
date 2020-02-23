﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Guzhikova.Task10.Model;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;

namespace Guzhikova.Task10.Control
{
    public class DBManage
    {
        private string _connectionString = @"Data Source=ANASTASIA\SQLEXPRESS;Initial Catalog=User_management;Integrated Security=True";

        public WebUser AddUser(WebUser user)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "dbo.AddUser";

                var idParameter = new SqlParameter()
                {
                    DbType = System.Data.DbType.Int32,
                    ParameterName = "@id",
                    Direction = System.Data.ParameterDirection.Output
                };

                var loginParameter = new SqlParameter()
                {
                    DbType = System.Data.DbType.String,
                    ParameterName = "@login",
                    Value = user.Login,
                    Direction = System.Data.ParameterDirection.Input
                };

                var passwordParameter = new SqlParameter()
                {
                    DbType = System.Data.DbType.String,
                    ParameterName = "@password",
                    Value = user.Password,
                    Direction = System.Data.ParameterDirection.Input
                };

                var emailParameter = new SqlParameter()
                {
                    DbType = System.Data.DbType.String,
                    ParameterName = "@email",
                    Value = user.Email,
                    Direction = System.Data.ParameterDirection.Input
                };

                command.Parameters.Add(loginParameter);
                command.Parameters.Add(passwordParameter);
                command.Parameters.Add(emailParameter);
                command.Parameters.Add(idParameter);

                connection.Open();
                command.ExecuteNonQuery();

                user.ID = (int)idParameter.Value;
                return user;
            }
        }
        public WebUser GetUserByLoginPassword(string login, string password)
        {
            WebUser user = null;            
            string passwordFromDB = null;
            password = ConvertToMD5(password);

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "GetUsersByLogin";

                var loginParameter = new SqlParameter()
                {
                    DbType = System.Data.DbType.String,
                    ParameterName = "@login",
                    Value = login,
                    Direction = System.Data.ParameterDirection.Input
                };

                command.Parameters.Add(loginParameter);

                connection.Open();
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    passwordFromDB = reader["Password"] as string;

                    if (password.Equals(passwordFromDB))
                    {
                        user = new WebUser
                        {
                            ID = (int)reader["ID"],
                            Login = reader["Login"] as string,
                            Password = passwordFromDB,
                            Email = reader["Email"] as string
                        };
                    }
                }

                return user;
            }
        }
        private string ConvertToMD5(string password)
        {
            var md5 = MD5.Create();
            var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(password));

            return Convert.ToBase64String(hash);
        }
    }
}