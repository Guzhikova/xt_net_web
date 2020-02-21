using Guzhikova.Task6.Dao.Interfaces;
using Guzhikova.Task6.Entities;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Users.DAL
{
    public class UserDbDao : IUserDao
    {
        private string _connectionString = @"Data Source=ANASTASIA\SQLEXPRESS;Initial Catalog=UsersAndAwards;Integrated Security=True";
        public User Add(User user)
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

                var nameParameter = new SqlParameter()
                {
                    DbType = System.Data.DbType.String,
                    ParameterName = "@name",
                    Value = user.Name,
                    Direction = System.Data.ParameterDirection.Input
                };

                var dateOfBirthParameter = new SqlParameter()
                {
                    DbType = System.Data.DbType.Date,
                    ParameterName = "@date_of_birth",
                    Value = user.DateOfBirth,
                    Direction = System.Data.ParameterDirection.Input
                };

                var imageParameter = new SqlParameter()
                {
                    DbType = System.Data.DbType.Binary,
                    ParameterName = "@image",
                    Value = user.Image,
                    Direction = System.Data.ParameterDirection.Input
                };

                command.Parameters.Add(nameParameter);
                command.Parameters.Add(dateOfBirthParameter);
                command.Parameters.Add(imageParameter);
                command.Parameters.Add(idParameter);

                connection.Open();
                command.ExecuteNonQuery();

                user.Id = (int)idParameter.Value;
                return user;
            }
        }

        public void DeleteById(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "dbo.DeleteUserById";

                var idParameter = new SqlParameter()
                {
                    DbType = System.Data.DbType.Int32,
                    ParameterName = "@id",
                    Value = id,
                    Direction = System.Data.ParameterDirection.Input
                };

                command.Parameters.Add(idParameter);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public IEnumerable<User> GetAll()
        {
            List<User> Users = new List<User>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "dbo.GetUsers";

                connection.Open();
                var reader = command.ExecuteReader();

                while (reader.Read())
                {

                    Users.Add(new User
                    {
                        Id = (int)reader["Id"],
                        Name = reader["Name"] as string,
                        DateOfBirth = (reader["Date_of_birth"] != DBNull.Value)
                            ? (DateTime)reader["Date_of_birth"]
                            : default(DateTime),
                        Image = reader["Image"] as byte[]
                    });
                }
            }
            return Users;
        }

        public User GetById(int id)
        {
            User user = new User();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "GetUserById";

                var idParameter = new SqlParameter()
                {
                    DbType = System.Data.DbType.Int32,
                    ParameterName = "@id",
                    Value = id,
                    Direction = System.Data.ParameterDirection.Input
                };


                command.Parameters.Add(idParameter);

                connection.Open();
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    user = new User
                    {
                        Id = id,
                        Name = reader["Name"] as string,
                        DateOfBirth = (reader["Date_of_birth"] != DBNull.Value)
                            ? (DateTime)reader["Date_of_birth"]
                            : default(DateTime),
                        Image = reader["Image"] as byte[]
                    };
                }
            }
            return user;
        }

        public string SaveUsers()
        {
            return "";
        }

        public User Update(User user)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "dbo.UpdateUser";

                var idParameter = new SqlParameter()
                {
                    DbType = System.Data.DbType.Int32,
                    ParameterName = "@id",
                    Value = user.Id,
                    Direction = System.Data.ParameterDirection.Input
                };

                var nameParameter = new SqlParameter()
                {
                    DbType = System.Data.DbType.String,
                    ParameterName = "@name",
                    Value = user.Name,
                    Direction = System.Data.ParameterDirection.Input
                };

                var dateOfBirthParameter = new SqlParameter()
                {
                    DbType = System.Data.DbType.Date,
                    ParameterName = "@date_of_birth",
                    Value = user.DateOfBirth,
                    Direction = System.Data.ParameterDirection.Input
                };

                var imageParameter = new SqlParameter()
                {
                    DbType = System.Data.DbType.Binary,
                    ParameterName = "@image",
                    Value = (object)user.Image ?? DBNull.Value,
                    Direction = System.Data.ParameterDirection.Input
                };

                command.Parameters.Add(idParameter);
                command.Parameters.Add(nameParameter);
                command.Parameters.Add(dateOfBirthParameter);
                command.Parameters.Add(imageParameter);
                

                connection.Open();
                command.ExecuteNonQuery();               
            }
            return user;
        } 
    }
}
