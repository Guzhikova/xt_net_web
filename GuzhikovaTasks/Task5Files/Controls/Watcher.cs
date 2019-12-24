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

        private FileSystemWatcher _watcher;
        private BackupsLog _backupsLog;


        public void Run(string path)
        {
            using (_watcher = new FileSystemWatcher(path, ".txt"))
            {
                _watcher.IncludeSubdirectories = true;

                _watcher.NotifyFilter = NotifyFilters.LastWrite
                                     | NotifyFilters.FileName
                                     | NotifyFilters.DirectoryName
                                     | NotifyFilters.CreationTime
                                     | NotifyFilters.Attributes;

                _watcher.Changed += OnChanged;
                _watcher.Created += OnChanged;
                _watcher.Deleted += OnChanged;
                _watcher.Renamed += OnChanged;

                _watcher.EnableRaisingEvents = true;

                Console.WriteLine("{0} Для выхода из режима нажмите 'q'{0}", Environment.NewLine);
                string entered = "";

                do
                {
                    entered = Console.ReadLine();
                }
                while (entered != "q");
            }
        }

        //private void OnRenamed(object sender, RenamedEventArgs e)
        //{
        //    try
        //    {
        //        _watcherFS.EnableRaisingEvents = false;

        //        CommitNewChanges();

        //        Console.WriteLine($"~ Изменение сохранено: File {e.Name}: {e.ChangeType + Environment.NewLine}");
        //    }
        //    finally
        //    {
        //        _watcherFS.EnableRaisingEvents = true;
        //    }


        //}

        private void OnChanged(object sender, FileSystemEventArgs e)
        {
            try
            {
                _watcher.EnableRaisingEvents = false;

                CommitNewChanges();

                Console.WriteLine($"~ Изменение сохранено:  File {e.FullPath}: {e.ChangeType + Environment.NewLine}");

            }
            finally
            {
                _watcher.EnableRaisingEvents = true;
            }
        }

        private void CommitNewChanges()
        {
            try
            {
                BackupFolder backupFolder = new BackupFolder();
                List<FileData> bacupsList = backupFolder.TxtFiles;

                _backupsLog.AddChangesToDictionary(DateTime.Now, bacupsList);

                JsonAdapter<BackupsLog> jsonAdapter = new JsonAdapter<BackupsLog>();
                jsonAdapter.SaveToJsonFile(_backupsLog);
            }
            catch (Exception ex)
            {
                Console.WriteLine("The process failed: {0}{1}{2}", ex.Message, Environment.NewLine, ex.StackTrace);
            }
        }
    }
}

