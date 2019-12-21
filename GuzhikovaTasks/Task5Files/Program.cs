using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5Files
{
    class Program
    {
        static void Main(string[] args)
        {


            BackupFolder mainFloder = new BackupFolder();
            BackupsLog b = new BackupsLog();

            JsonAdapter < BackupsLog > jsonAdapter= new JsonAdapter<BackupsLog>();


            BackupsLog backupsLog = new BackupsLog();

            Dictionary<DateTime, List < FileData >> dictionary = backupsLog.GetDictionaryFromJson() ?? new Dictionary<DateTime, List<FileData>>();
            Console.WriteLine("---------------" + dictionary.Count());

            BackupWorker bw = new BackupWorker();
            bw.ShowBackupPossibleDates();

            Watcher watcher = new Watcher();
            watcher.Run(mainFloder.Info.FullName);

            Console.ReadKey();
        }

        static void Show<T>(IEnumerable<T> collection)
        {

            foreach (var item in collection)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
}
