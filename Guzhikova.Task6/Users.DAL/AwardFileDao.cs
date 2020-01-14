using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Users.Dao.Interfaces;
using Newtonsoft.Json;
using System.IO;
using Guzhikova.Task6.Entities;

namespace Users.DAL
{
    public class AwardFileDao : IAwardDao
    {
        private FileStream _stream = null;
        private Dictionary<int, Award> _awards = null;
        private string _path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Awards.json");

        public Award Add(Award award)
        {
            _awards = ReadAwardsFromFile();

            if (award.Id == 0)
            {
                var lastId = _awards.Keys.Count > 0
                  ? _awards.Keys.Max()
                  : 0;

                award.Id = lastId + 1;
            }
            _awards.Add(award.Id, award);

            WriteToFile();

            return award;
        }

        public void DeleteById(int id)
        {
            _awards = ReadAwardsFromFile();

            if (!_awards.ContainsKey(id))
            {
                throw new ArgumentOutOfRangeException("Id", "Error! Award with this id does not exist!");
            }
            _awards.Remove(id);

            WriteToFile();

        }

        public IEnumerable<Award> GetAll()
        {
            return ReadAwardsFromFile().Values;
        }

        public Award GetById(int id)
        {
            _awards = ReadAwardsFromFile();

            if (!_awards.ContainsKey(id))
            {
                throw new ArgumentOutOfRangeException("Id", "Error! Award with this id does not exist!");
            }
            return _awards[id];
        }

        public Award RewriteAward(Award award)
        {
            _awards = ReadAwardsFromFile();

            if (!_awards.ContainsKey(award.Id))
            {
                throw new ArgumentOutOfRangeException("Id", "Error! Award with this id does not exist!");
            }

            _awards[award.Id] = award;

            WriteToFile();

            return award;
        }

        public string SaveAwards()
        {
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

            Dictionary<int, Award> awards = JsonConvert.DeserializeObject<Dictionary<int, Award>>(content)
                ?? new Dictionary<int, Award>();

            return awards;
        }

        private void WriteToFile()
        {
            string jsonString = JsonConvert.SerializeObject(_awards);

            using (_stream = new FileStream(_path, FileMode.Create, FileAccess.Write, FileShare.ReadWrite))
            {

                using (StreamWriter writer = new StreamWriter(_stream, System.Text.Encoding.Default))
                {
                    writer.Write(jsonString);
                }
            }
        }
    }
}
