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
            GetBeckupsDictionary();
            _backupfolder = new BackupFolder();
        }
        private Dictionary<DateTime, List<FileData>> _dictionary;
        private BackupFolder _backupfolder;
        public void Restore(List<FileData> backupFiles)
        {
            //  DeleteOldFiles(_backupfolder.TxtFiles);
            int endOfBackaupFolderPath = _backupfolder.Info.FullName.Length;

            foreach (var file in backupFiles)
            {
                string relativePath = file.Path.Substring(endOfBackaupFolderPath);
                if (relativePath.Length == 0)
                {
                    FileInfo fileInfo = file.FileDateToFileInfo();



                    //fileInfo.Create().Close();

                    using (Stream stream = File.Open(fileInfo.FullName, FileMode.OpenOrCreate, FileAccess.Write, FileShare.ReadWrite))
                    {
                        using (StreamWriter writer = new StreamWriter(stream, System.Text.Encoding.Default))
                        {
                            Console.WriteLine("***********" + file.Content);
                            writer.Write(file.Content);
                        }
                    }
                     
                }

                Console.WriteLine($"-------------{relativePath}  = {relativePath.Length}");
            }

        }

        /// <summary>
        /// Gets user chosen date of backup and return list of txt-files from this date
        /// </summary>
        public List<FileData> GetBackupByDate()
        {
            ShowBackupPossibleDates();

            int index = ReadChosenIndexOfDate();

            while (index < 0 || index >= _dictionary.Count)
            {
                Console.WriteLine("Выбранного номера даты не существует. Пожалуста, введите снова:");
                ReadChosenIndexOfDate();
            }

            return _dictionary.Values.ElementAt(index);
        }

        private void GetDirectoriesFromPath()
        {

        }
        private void DeleteOldFiles(List<FileData> files)
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

        private void GetBeckupsDictionary()
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

        private void ShowBackupPossibleDates()
        {
            Console.WriteLine($"{0}Выберите желаемую дату для восстановления и введите соответсвующий ей номер: {0}", Environment.NewLine);

            int index = 1;
            foreach (DateTime date in _dictionary.Keys)
            {
                Console.WriteLine("{0}: {1:f}", index, date);
                index++;
            }
        }

        private int ReadChosenIndexOfDate()
        {
            int index = 0;

            string selected = Console.ReadLine();
            Int32.TryParse(selected, out index);

            return index - 1;
        }
    }
}
