using Guzhikova.Task6.Dao.Interfaces;
using Guzhikova.Task6.Entities;

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
    public class AwardLogic : IAwardLogic
    {
        private readonly IAwardDao _awardDao;

        public AwardLogic(IAwardDao awardDao)
        {
            _awardDao = awardDao;
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

        public IEnumerable<Award> GetUserAwardsByUserId(int id)
        {
            return GetAll().Where(item => item.UsersId.Contains(id));
        }

        public Award RewriteAward(Award award)
        {
            return _awardDao.RewriteAward(award);
        }

        public string SaveAwards()
        {
            return _awardDao.SaveAwards();
        }

    }
}

