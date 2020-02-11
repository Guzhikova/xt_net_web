using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace Task5Files
{
   internal class Watcher
    {
        private BackupsLog _backupsLog;
        private FileSystemWatcher _fsw;

        public Watcher()
        {
            _backupsLog = new BackupsLog();
            _backupsLog.BackupsLogDictionary = _backupsLog.GetDictionaryFromJson();

        }

        public void Run(string path)
        {
            using (_fsw = new FileSystemWatcher(path, "*.txt"))
            {
                _fsw.IncludeSubdirectories = true;

                _fsw.NotifyFilter = NotifyFilters.LastWrite
                                     | NotifyFilters.FileName
                                     | NotifyFilters.DirectoryName
                                     | NotifyFilters.CreationTime
                                     | NotifyFilters.Attributes;

                _fsw.Changed += OnChanged;
                _fsw.Created += OnChanged;
                _fsw.Deleted += OnChanged;
                _fsw.Renamed += OnRenamed; 

                _fsw.EnableRaisingEvents = true;

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
                _fsw.EnableRaisingEvents = false;
                CommitNewChanges();
                Console.WriteLine($"~ Изменение сохранено:  File {e.Name}: {e.ChangeType + Environment.NewLine}");
            }
            finally
            {
                _fsw.EnableRaisingEvents = true;
            }
        }

        private void OnChanged(object sender, FileSystemEventArgs e)
        {
            try
            {
                _fsw.EnableRaisingEvents = false;
                CommitNewChanges();
                Console.WriteLine($"~ Изменение сохранено:  File {e.Name}: {e.ChangeType + Environment.NewLine}");
            }
            finally
            {
                _fsw.EnableRaisingEvents = true;
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

