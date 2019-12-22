using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5Files
{

    class BackupControl
    {

        public BackupControl()
        {
            GetBackupsDictionary();

            _backupfolder = new BackupFolder();
        }

        private Dictionary<DateTime, List<FileData>> _dictionary;

        private BackupFolder _backupfolder;


        public void SuggestAndMakeRestore()
        {
            ShowBackupPossibleDates();

            List<FileData> backupFiles = GetBackupFilesByChosenDate();

            if (backupFiles != null)
            {
                DeleteCurrentFiles(_backupfolder.TxtFiles);

                RestoreFiles(backupFiles);
            }
        }


        private void RestoreFiles(List<FileData> backupFiles)
        {
            int endOfBackaupFolderPath = _backupfolder.Info.FullName.Length;

            foreach (var file in backupFiles)
            {
                if (file.Path == _backupfolder.Info.FullName)
                {
                    file.CreateFile();
                }
                else
                {
                    string relativePath = file.Path.Substring(endOfBackaupFolderPath + 1);

                    string[] folderNames = relativePath.Split(Path.DirectorySeparatorChar);

                    foreach (var name in folderNames)
                    {
                        string currentPath = $"{_backupfolder.Info.FullName}\\{name}";

                        if (!Directory.Exists(currentPath))
                        {
                            Directory.CreateDirectory(currentPath);
                        }
                    }

                    file.CreateFile();
                }

            }

        }
        private void DeleteCurrentFiles(List<FileData> files)
        {
            try
            {
                foreach (var file in files)
                {
                    File.Delete(file.FullName);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + Environment.NewLine + ex.StackTrace);
            }

        }


        /// <summary>
        /// Gets user chosen date of backup and return list of txt-files from this date.
        /// Return null if user chosen exit
        /// </summary>
        private List<FileData> GetBackupFilesByChosenDate()
        {
            int index = ReadChosenIndexOfDate();

            while (index < 0)
            {
                if (index == -1)
                {
                    return null;
                }

                Console.WriteLine("Выбранного номера даты не существует. Пожалуста, введите снова:");
                index = ReadChosenIndexOfDate();
            }

            return _dictionary.Values.ElementAt(index);
        }


        /// <summary>
        /// Read user chosen date of backup
        /// </summary>
        /// <returns>
        /// Return index of chosen date for beckups dictionary.
        /// Return (-1) if user wants to exit
        /// Return (-2) if user entered incorrect data
        /// </returns>

        private int ReadChosenIndexOfDate()
        {
            string selected = Console.ReadLine();

            if (selected.ToLower().Equals("q"))
            {
                return -1;
            }

            int index = 0;

            Int32.TryParse(selected, out index);

            return (index <= 0 || index > _dictionary.Count) ? -2 : index - 1;
        }

        private void ShowBackupPossibleDates()
        {
            Console.WriteLine($"{0}Выберите желаемую дату для восстановления и введите соответсвующий ей номер: {0}", Environment.NewLine);

            int index = 1;
            foreach (DateTime date in _dictionary.Keys)
            {
                Console.WriteLine("{0}: {1:f}", index, date);
                index++;
            }
            Console.WriteLine("   Для выхода нажмите 'q'");
        }

        /// <summary>
        /// Gets backups dictionary from log file and assigns it to field _dictionary.
        /// </summary>
        private void GetBackupsDictionary()
        {
            BackupsLog backupsLog = new BackupsLog();
            _dictionary = new Dictionary<DateTime, List<FileData>>();

            try
            {
                _dictionary = backupsLog.GetDictionaryFromJson();
            }
            catch (Exception ex)
            {
                ////////////////////написать на отсутствие файла
            }
        }
    }
}
