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
            BackupsControl logControls = new BackupsControl();
            JsonAdapter jsonAdapter = new JsonAdapter();


            //List<FileData> txtFiles = mainFloder.TxtFiles;
            //Dictionary<DateTime, List<FileInfo>> backups = new Dictionary<DateTime, List<FileInfo>>();
            //backups.AddToLog = 

            //logControls.AddToLog(DateTime.Now, txtFiles);
            //b.BackupsLogDictionary = logControls.BackupsLogDictionary;


            //foreach (var item in logControls.BackupsLogDictionary)
            //{
            //    Console.WriteLine(item.Key.ToString());

            //    Show(item.Value);
            //}

            //jsonAdapter.SaveToJsonFile($"{mainFloder.Info.FullName}\\Log.json", b);

            //Console.WriteLine(mainFloder.Info.FullName);
            //Console.WriteLine();

            //Show(txtFiles);

            //Watcher watcher = new Watcher();
            //watcher.Run(mainFloder.Info.FullName);


            BackupsLog backlog = new BackupsLog();
            backlog = jsonAdapter.ReadFromJsonFile<BackupsLog>($"{mainFloder.Info.FullName}\\Log.json");

            Dictionary<DateTime, List < FileData >> dictionary = backlog.BackupsLogDictionary;
            Console.WriteLine("---------------" + dictionary.Count());


            foreach (var item in dictionary)
            {
                Console.WriteLine(item.Key.ToString());

                Show(item.Value);
            }

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
