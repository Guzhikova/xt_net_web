using Guzhikova.Task6.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Users.BLLInterfaces
{
    public interface IAwardLogic
    {
        Award Add(Award award);

        void DeleteById(int id);

        IEnumerable<Award> GetAll();

        Award GetById(int id);

        string SaveAwardsToFile();

        Award RewriteAward(Award award);
    }
}
