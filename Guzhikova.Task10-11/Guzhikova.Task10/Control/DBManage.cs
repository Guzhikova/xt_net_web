using System;
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


            }
            return user;
        }

        public List<WebUser> GetAllUsers()
        {
            WebUser user = null;
            List<WebUser> users = new List<WebUser>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "GetAllUsers";

               
                connection.Open();
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                        user = new WebUser
                        {
                            ID = (int)reader["ID"],
                            Login = reader["Login"] as string,
                            Password = reader["Password"] as string,
                            Email = reader["Email"] as string
                        };

                    users.Add(user);
                }
            }
            return users;
        }

        public string[] GetUserRoles(string login)
        {
            var roles = new List<string>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "GetUserRoles";

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

                    roles.Add(reader["Title"] as string);
                }

                return roles.ToArray();
            }
        }

        public void SetUserAsAdmin(int userId)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "SetUserAsAdmin";

                var idParameter = new SqlParameter()
                {
                    DbType = System.Data.DbType.Int32,
                    ParameterName = "@id_user",
                    Value = userId,
                    Direction = System.Data.ParameterDirection.Input
                };

                command.Parameters.Add(idParameter);

                connection.Open();
                var reader = command.ExecuteNonQuery();
            }
        }

        public void DeleteUsersAdminRole()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "DeleteUsersAdminRole";

                connection.Open();
                var reader = command.ExecuteNonQuery();
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