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

        private FileSystemWatcher _watcherFS;
        private BackupsLog _backupsLog;


        public void Run(string path)
        {
            using (_watcherFS = new FileSystemWatcher(path, "*.txt"))
            {
                _watcherFS.IncludeSubdirectories = true;

                _watcherFS.NotifyFilter = NotifyFilters.LastWrite
                                     | NotifyFilters.FileName
                                     | NotifyFilters.DirectoryName
                                     | NotifyFilters.CreationTime
                                     | NotifyFilters.Attributes;

                _watcherFS.Changed += OnChanged;
                _watcherFS.Created += OnChanged;
                _watcherFS.Deleted += OnChanged;
                _watcherFS.Renamed += OnRenamed;

                _watcherFS.EnableRaisingEvents = true;

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
            try
            {
                _watcherFS.EnableRaisingEvents = false;

                CommitNewChanges();

                Console.WriteLine($"~ Изменение сохранено: File {e.Name}: {e.ChangeType + Environment.NewLine}");
            }
            finally
            {
                _watcherFS.EnableRaisingEvents = true;
            }


        }

        private void OnChanged(object sender, FileSystemEventArgs e)
        {
            try
            {
                _watcherFS.EnableRaisingEvents = false;

                CommitNewChanges();

                Console.WriteLine($"~ Изменение сохранено:  File {e.Name}: {e.ChangeType + Environment.NewLine}");
            }
            finally
            {
                _watcherFS.EnableRaisingEvents = true;
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

