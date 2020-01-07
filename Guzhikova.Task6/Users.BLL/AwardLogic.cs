using Guzhikova.Task6.Dao.Interfaces;
using Guzhikova.Task6.Entities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Users.BLLInterfaces;
using Users.Dao.Interfaces;

namespace Users.BLL
{
    public class AwardLogic: IAwardLogic
    {
        private readonly IAwardDao _awardDao; 
        private System.IO.Stream _stream;
        private string _path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Awards.json");

        public AwardLogic(IAwardDao awardDao)
        {
            _awardDao = awardDao; 

            IEnumerable<Award> awards = null;

            try
            {
                awards = ReadAwardsFromFile();
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e.Message} {Environment.NewLine}{e.StackTrace}");
            }

            if (awards != null)
            {
                foreach (var award in awards)
                {
                    _awardDao.Add(award);
                }
            }
        }

        public Award Add(Award award)
        {
            return _awardDao.Add(award);
        }

        public void DeleteById(int id)
        {
            _awardDao.DeleteById(id);
        }

        public IEnumerable<Award> GetAll()
        {
            return _awardDao.GetAll();
        }

        public Award GetById(int id)
        {
           return _awardDao.GetById(id);
        }

        public Award RewriteAward(Award award)
        {
            return _awardDao.RewriteAward(award);
        }

        public string SaveAwardsToFile()
        {
            IEnumerable<Award> awards = GetAll();
            string jsonString = JsonConvert.SerializeObject(awards);

            using (_stream = File.Open(_path, FileMode.OpenOrCreate, FileAccess.Write, FileShare.ReadWrite))
            {
                using (StreamWriter writer = new StreamWriter(_stream, System.Text.Encoding.Default))
                {
                    writer.Write(jsonString);
                }
            }
            return _path;
        }

        private IEnumerable<Award> ReadAwardsFromFile()
        {
            string content = "";

            using (_stream = File.Open(_path, FileMode.OpenOrCreate, FileAccess.Read, FileShare.ReadWrite))
            {
                using (StreamReader reader = new StreamReader(_stream, System.Text.Encoding.Default))
                {
                    content = reader.ReadToEnd();
                }
            }

            return JsonConvert.DeserializeObject<IEnumerable<Award>>(content);
        }
    }
}

