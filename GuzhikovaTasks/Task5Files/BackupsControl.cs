using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5Files
{
    class BackupsControl : Backups
    {

        public void AddToLog(DateTime date, List<FileData> files)
        {
            if (BackupsLog == null)
            {
                //может в конструктор??

                BackupsLog = new Dictionary<DateTime, List<FileData>>();
            }

            BackupsLog.Add(date, files);

        }


    }
}
