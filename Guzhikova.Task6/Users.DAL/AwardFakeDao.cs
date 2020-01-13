using Guzhikova.Task6.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Users.Dao.Interfaces;

namespace Users.DAL
{
    public class AwardFakeDao: IAwardDao 
    {
        private static readonly Dictionary<int, Award> _awards = new Dictionary<int, Award>();
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

        public Award RewriteAward(Award award)
        {
            if (!_awards.ContainsKey(award.Id))
            {
                throw new ArgumentOutOfRangeException("Id", "Error! Award with this id does not exist!");
            }

            _awards[award.Id] = award;

            return award;
        }
    }
}

