using Guzhikova.Task6.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Users.Dao.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Users.DAL
{
    public class AwardMemoryDao : IAwardDao
    {
        private readonly Dictionary<int, Award> _awards = null;
        private FileStream _stream = null;
        private string _path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Awards.json");

        public AwardMemoryDao()
        {
            _awards = ReadAwardsFromFile() ?? new Dictionary<int, Award>();
        }

        public Award Add(Award award)
        {
            if (award.Id == default(int))
            {
                var lastId = _awards.Keys.Count > 0
                  ? _awards.Keys.Max()
                  : 0;

                award.Id = lastId + 1;
            }
            _awards.Add(award.Id, award);

            return award;
        }

        public void DeleteById(int id)
        {
            if (!_awards.ContainsKey(id))
            {
                throw new ArgumentOutOfRangeException("Id", "Error! Award with this id does not exist!");
            }
            _awards.Remove(id);

        }

        public IEnumerable<Award> GetAll()
        {
            return _awards.Values;
        }

        public Award GetById(int id)
        {
            if (!_awards.ContainsKey(id))
            {
                throw new ArgumentOutOfRangeException("Id", "Error! Award with this id does not exist!");
            }
            return _awards[id];
        }

        public Award UpdateAward(Award award)
        {
            if (!_awards.ContainsKey(award.Id))
            {
                throw new ArgumentOutOfRangeException("Id", "Error! Award with this id does not exist!");
            }

            _awards[award.Id] = award;

            return award;
        }

        public string SaveAwards()
        {
            string jsonString = JsonConvert.SerializeObject(_awards);

            using (_stream = new FileStream(_path, FileMode.Create, FileAccess.Write, FileShare.ReadWrite))
            {

                using (StreamWriter writer = new StreamWriter(_stream, System.Text.Encoding.Default))
                {
                    writer.Write(jsonString);
                }
            }
            return _path;
        }

        private Dictionary<int, Award> ReadAwardsFromFile()
        {
            string content = "";

            using (_stream = File.Open(_path, FileMode.OpenOrCreate, FileAccess.Read, FileShare.ReadWrite))
            {
                using (StreamReader reader = new StreamReader(_stream, System.Text.Encoding.Default))
                {
                    content = reader.ReadToEnd();
                }
            }

            return JsonConvert.DeserializeObject<Dictionary<int, Award>>(content);
        }
    }
}

