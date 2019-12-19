using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5Files
{
    class BackupsControl : BackupsLog
    {

        public void AddToLog(DateTime date, List<FileData> files)
        {
            if (BackupsLogDictionary == null)
            {
                //может в конструктор??

                BackupsLogDictionary = new Dictionary<DateTime, List<FileData>>();
            }

            BackupsLogDictionary.Add(date, files);

        }


    }
}
