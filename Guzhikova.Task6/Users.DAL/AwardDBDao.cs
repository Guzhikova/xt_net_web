using Guzhikova.Task6.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Users.Dao.Interfaces;

namespace Users.DAL
{
    public class AwardDbDao : IAwardDao
    {
        private string _connectionString = @"Data Source=ANASTASIA\SQLEXPRESS;Initial Catalog=UsersAndAwards;Integrated Security=True";

        public Award Add(Award award)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "dbo.AddAward";

                var idParameter = new SqlParameter()
                {
                    DbType = System.Data.DbType.Int32,
                    ParameterName = "@id",
                    Direction = System.Data.ParameterDirection.Output
                };

                var titleParameter = new SqlParameter()
                {
                    DbType = System.Data.DbType.String,
                    ParameterName = "@title",
                    Value = award.Title,
                    Direction = System.Data.ParameterDirection.Input
                };

                var imageParameter = new SqlParameter()
                {
                    DbType = System.Data.DbType.Binary,
                    ParameterName = "@image",
                    Value = (object)award.Image ?? DBNull.Value,
                    Direction = System.Data.ParameterDirection.Input
                };

                command.Parameters.Add(titleParameter);
                command.Parameters.Add(imageParameter);
                command.Parameters.Add(idParameter);

                connection.Open();
                command.ExecuteNonQuery();

                award.Id = (int)idParameter.Value;
            }

            //AddUsersIdToAward(award);

            return award;
        }
           

        public void DeleteById(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "dbo.DeleteAwardById";

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

        public IEnumerable<Award> GetAll()
        {
            Dictionary<int, Award> awardsDictionary = new Dictionary<int, Award>();
            Award award = new Award();
            int id = 0;

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "dbo.GetAwards";

                connection.Open();
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    id = (int)reader["ID"];
                    award = new Award();

                    if (awardsDictionary.ContainsKey(id))
                    {
                        award = awardsDictionary[id];

                        if (reader["user_ID"] != DBNull.Value)
                        {
                            award.UsersId.Add((int)reader["user_ID"]);
                        }

                        awardsDictionary[award.Id] = award;
                        
                    }
                    else
                    {
                        award.Id = (int)reader["Id"];
                        award.Title = reader["Title"] as string;
                        award.Image = reader["Image"] as byte[];

                        if (reader["user_ID"] != DBNull.Value)
                        {
                            award.UsersId.Add((int)reader["user_ID"]);                            
                        }
                        awardsDictionary.Add(award.Id, award);
                    };
                }
            }
            return awardsDictionary.Values;
        }

        public Award GetById(int id)
        {
            Award award = new Award();
            award.Id = id;            

            GetAwardWithoutUsersById(award);
            GetUsersIdForAward(award);

            return award;
        }

        //public Award GetById(int id)
        //{
        //    Award award = new Award();

        //    using (SqlConnection connection = new SqlConnection(_connectionString))
        //    {
        //        var command = connection.CreateCommand();
        //        command.CommandType = System.Data.CommandType.StoredProcedure;
        //        command.CommandText = "GetAwardById";

        //        var idParameter = new SqlParameter()
        //        {
        //            DbType = DbType.Int32,
        //            ParameterName = "@id",
        //            Value = id,
        //            Direction = System.Data.ParameterDirection.Input
        //        };

        //        var titleParameter = new SqlParameter()
        //        {
        //            SqlDbType = SqlDbType.NVarChar,
        //            Size = 50,
        //            ParameterName = "@title",
        //            Direction = System.Data.ParameterDirection.Output
        //    };

        //        var imageParameter = new SqlParameter()
        //        {
        //            SqlDbType = SqlDbType.VarBinary,
        //            Size = 8000,
        //            ParameterName = "@image",
        //            Direction = System.Data.ParameterDirection.Output
        //        };

        //        command.Parameters.Add(idParameter);
        //        command.Parameters.Add(titleParameter);
        //        command.Parameters.Add(imageParameter);

        //        connection.Open();
        //        var reader = command.ExecuteReader();

        //        award.Id = id;

        //        award.Title = titleParameter.Value as string;
        //        award.Image = imageParameter.Value as byte[];



        //        while (reader.Read())
        //        {
        //            award.UsersId.Add((int)reader["user_ID"]);
        //        }
        //    }
        //    return award;
        //}

        public string SaveAwards()
        {
            return "";
        }

        public Award UpdateAward(Award award)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "dbo.UpdateAward";

                var idParameter = new SqlParameter()
                {
                    DbType = System.Data.DbType.Int32,
                    ParameterName = "@id",
                    Value = award.Id,
                    Direction = System.Data.ParameterDirection.Input
                };

                var titleParameter = new SqlParameter()
                {
                    DbType = System.Data.DbType.String,
                    ParameterName = "@title",
                    Value = award.Title,
                    Direction = System.Data.ParameterDirection.Input
                };

                var imageParameter = new SqlParameter()
                {
                    DbType = System.Data.DbType.Binary,
                    ParameterName = "@image",
                    Value = (object)award.Image ?? DBNull.Value,
                    Direction = System.Data.ParameterDirection.Input
                };


                command.Parameters.Add(idParameter);
                command.Parameters.Add(titleParameter);
                command.Parameters.Add(imageParameter);


                connection.Open();
                command.ExecuteNonQuery();
            }


            return award;
        }

        private void AddUsersIdToAward(Award award)
        {
            foreach (var userId in award.UsersId)
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    var command = connection.CreateCommand();
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = "dbo.AddAward";

                    var awardIdParameter = new SqlParameter()
                    {
                        DbType = System.Data.DbType.Int32,
                        ParameterName = "@id_award",
                        Value = award.Id,
                        Direction = System.Data.ParameterDirection.Input
                    };

                    var userIdParameter = new SqlParameter()
                    {
                        DbType = System.Data.DbType.Int32,
                        ParameterName = "@id_user",
                        Value = userId,
                        Direction = System.Data.ParameterDirection.Input
                    };

                    command.Parameters.Add(awardIdParameter);
                    command.Parameters.Add(userIdParameter);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        private Award GetAwardWithoutUsersById(Award award)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {

                var command = connection.CreateCommand();
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "GetAwardWithoutUsersById";

                var idParameter = new SqlParameter()
                {
                    DbType = DbType.Int32,
                    ParameterName = "@id",
                    Value = award.Id,
                    Direction = System.Data.ParameterDirection.Input
                };

                command.Parameters.Add(idParameter);

                connection.Open();
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    award.Title = reader["Title"] as string;
                    award.Image = reader["Image"] as byte[];
                }
            }
            return award;
        }

        private Award GetUsersIdForAward(Award award)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "GetUsersIdForAward";

                var idParameter = new SqlParameter()
                {
                    DbType = DbType.Int32,
                    ParameterName = "@id",
                    Value = award.Id,
                    Direction = System.Data.ParameterDirection.Input
                };

                command.Parameters.Add(idParameter);

                connection.Open();
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    award.UsersId.Add((int)reader["user_ID"]);
                }
            }
            return award;
        }
    }
}
