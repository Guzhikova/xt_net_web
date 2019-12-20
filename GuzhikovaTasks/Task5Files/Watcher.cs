using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace Task5Files
{
    class Watcher
    {
        public Watcher ()
        {
            _backupsLog = new BackupsLog();       
            _backupsLog.BackupsLogDictionary = _backupsLog.GetDictionaryFromJson();

            Console.WriteLine("Constructor: " + _backupsLog.BackupsLogDictionary.Count());


        }


        private BackupsLog _backupsLog;
        public void Run(string path)
        {
            using (FileSystemWatcher watcher = new FileSystemWatcher())
            {
                watcher.Path = path;

                watcher.NotifyFilter = NotifyFilters.LastWrite
                                     | NotifyFilters.FileName
                                     | NotifyFilters.DirectoryName;

                watcher.Filter = "*.txt";

                watcher.Changed += OnChanged;
                watcher.Created += OnChanged;
                watcher.Deleted += OnChanged;
                watcher.Renamed += OnRenamed;

                watcher.EnableRaisingEvents = true;

                Console.WriteLine("Press 'q' to quit the sample.");
                while (Console.Read() != 'q') ;
            }
        }

        private static void OnRenamed(object sender, RenamedEventArgs e)
        {
            Watcher watcher =  new Watcher();
            Console.WriteLine("OnRenamed *1: " + watcher._backupsLog.BackupsLogDictionary.Count());

            BackupFolder backupFolder = new BackupFolder();
            List<FileData> bacupsList = backupFolder.TxtFiles;


            //FileInfo changedFileInfo = new FileInfo(e.FullPath);
            //FileData changedFile = new FileData(changedFileInfo);

            

            watcher._backupsLog.AddChangesToDictionary(DateTime.Now, bacupsList);
            Console.WriteLine("OnRenamed *2: " + watcher._backupsLog.BackupsLogDictionary.Count());

            JsonAdapter<BackupsLog> jsonAdapter = new JsonAdapter<BackupsLog>();
            jsonAdapter.SaveToJsonFile(watcher._backupsLog);

            Console.WriteLine("***** " + e.OldFullPath);
            

            Console.WriteLine(e.Name + e.ChangeType);
        }

        private static void OnChanged(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine(e.Name + e.ChangeType);
        }
    }
}

