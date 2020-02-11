using Guzhikova.Task10.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Users.Dao.Interfaces
{
    public interface IAwardDao
    {
        Award Add(Award award);

        void DeleteById(int id);

        IEnumerable<Award> GetAll();
        Award GetById(int id);

        Award RewriteAward(Award award);

        /// <returns>Returns info where awards saved</returns>
        string SaveAwards();


    }
}
