using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5Files
{

    class BackupWorker
    {

        public BackupWorker()
        {
            GetBeckupsDictionary();
        }
        private Dictionary<DateTime, List<FileData>> _dictionary;

        /// <summary>
        /// Gets user chosen date of backup and return list of txt-files from this date
        /// </summary>
        public List<FileData> GetBackupByDate()
        {
            ShowBackupPossibleDates();

            int index = ReadChosenIndexOfDate();

            while (index < 0 || index >= _dictionary.Count )
            {
                Console.WriteLine("Выбранного номера даты не существует. Пожалуста, введите снова:");
                ReadChosenIndexOfDate();
            }

            return _dictionary.Values.ElementAt(index);
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
