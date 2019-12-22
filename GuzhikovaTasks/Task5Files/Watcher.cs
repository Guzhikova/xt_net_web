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
        public Watcher()
        {
            _backupsLog = new BackupsLog();
            _backupsLog.BackupsLogDictionary = _backupsLog.GetDictionaryFromJson();
        }


        private BackupsLog _backupsLog;

        public void Run(string path)
        {
            using (FileSystemWatcher watcher = new FileSystemWatcher())
            {
                watcher.Path = path;
                watcher.IncludeSubdirectories = true;

                watcher.NotifyFilter = NotifyFilters.LastWrite
                                     | NotifyFilters.FileName
                                     | NotifyFilters.DirectoryName
                                     |NotifyFilters.CreationTime
                                     | NotifyFilters.Attributes;

                watcher.Filter = "*.txt";

                watcher.Changed += OnChanged;
                watcher.Created += OnChanged;
                watcher.Deleted += OnChanged;
                watcher.Renamed += OnRenamed;

                watcher.EnableRaisingEvents = true;

                Console.WriteLine("{0} Для выхода из режима нажмите 'q'{0}", Environment.NewLine);

                string entered = "";

                do
                {
                    entered = Console.ReadLine();
                }
                while (entered != "q");                
            }
        }

        private void OnRenamed(object sender, RenamedEventArgs e)
        {
            Watcher watcher = new Watcher();

            watcher.CommitNewChanges(watcher);

            Console.WriteLine($"~ Изменение сохранено: File {e.Name}: {e.ChangeType + Environment.NewLine}");
        }

        private static void OnChanged(object sender, FileSystemEventArgs e)
        {
            Watcher watcher = new Watcher();

            watcher.CommitNewChanges(watcher);

            Console.WriteLine($"~ Изменение сохранено:  File {e.Name}: {e.ChangeType + Environment.NewLine}");
        }

        private void CommitNewChanges(Watcher watcher)
        {
            BackupFolder backupFolder = new BackupFolder();
            List<FileData> bacupsList = backupFolder.TxtFiles;

            watcher._backupsLog.AddChangesToDictionary(DateTime.Now, bacupsList);

            JsonAdapter<BackupsLog> jsonAdapter = new JsonAdapter<BackupsLog>();
            jsonAdapter.SaveToJsonFile(watcher._backupsLog);
        }
    }
}

