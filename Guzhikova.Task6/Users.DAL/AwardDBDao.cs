using Guzhikova.Task6.Entities;
using System;
using System.Collections.Generic;
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
            throw new NotImplementedException();
        }

        public void DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Award> GetAll()
        {
            Dictionary<int, Award> awardsDictionary = new Dictionary<int, Award>();
            Award award = new Award();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "dbo.GetAwards";

                connection.Open();
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    award = new Award
                    {
                        Id = (int)reader["Id"],
                        Title = reader["Title"] as string,
                        Image = reader["Image"] as byte[],
                    };

                    if(reader["user_ID"] != DBNull.Value)
                    {
                        award.UsersId.Add((int)reader["user_ID"]);


                    }
                    

                    if (awardsDictionary.Count>0)
                    {
                    if (awardsDictionary.ContainsKey(award.Id))
                        {
                            Award temp = awardsDictionary[award.Id];
                            temp.UsersId.Add(award.UsersId.);
                           
                            // awardsDictionary[award.Id] = 
                        }
                    }
                    else
                    {
                        awardsDictionary.Add(award.Id, award);
                    }
                }
            }
            return Users
        }

        public Award GetById(int id)
        {
            throw new NotImplementedException();
        }

        public string SaveAwards()
        {
            throw new NotImplementedException();
        }

        public Award UpdateAward(Award award)
        {
            throw new NotImplementedException();
        }
    }
}
