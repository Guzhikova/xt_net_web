using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5Files
{
    class BackupsLog
    {
        public Dictionary<DateTime, List<FileData>>  BackupsLogDictionary { get; set; }


        public Dictionary<DateTime, List<FileData>> GetDictionaryFromJson()
        {

            JsonAdapter<BackupsLog> jsonAdapter = new JsonAdapter<BackupsLog>();
            BackupFolder mainFloder = new BackupFolder();

                       
            return jsonAdapter.ReadFromJsonFile().BackupsLogDictionary ?? new Dictionary<DateTime, List<FileData>>();
        }

        public void AddChangesToDictionary(DateTime date, List<FileData> files)
        {
            if (BackupsLogDictionary == null)
            {
                //может в конструктор??
                Console.WriteLine("*****************************");
                BackupsLogDictionary = new Dictionary<DateTime, List<FileData>>();
            }

            BackupsLogDictionary.Add(date, files);

        }

    }
}
