using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5Files
{
    internal class ModeControls
    {
        public void ChoosingMode()
        {
            BackupFolder mainFloder = new BackupFolder();

            int mode = 0;

            do
            {
                ShowModes();
                mode = ReadSelectedMode();

                switch (mode)
                {
                    case 1:                        
                        Watcher watcher = new Watcher();
                        watcher.Run(mainFloder.Info.FullName);
                        break;

                    case 2:
                        BackupControls backupControls = new BackupControls();
                        backupControls.SuggestAndMakeRestore();
                        break;

                    default:
                        Console.WriteLine("{0}Работа с приложением завершена!", Environment.NewLine);
                        break;
                }
            } while (mode != 3);

        }

        private void ShowModes()
        {
            Console.WriteLine("Для дальнейшей работы с приложением выберите режим: {0}", Environment.NewLine);

            Console.WriteLine("1: НАБЛЮДЕНИЕ {0}2: ОТКАТ {0}3: Завершить работу с BACKUP SYSTEM{0}",
                Environment.NewLine);
        }

        private int ReadSelectedMode()
        {
            int mode = 0;

            do
            {
                string selected = Console.ReadLine();

                Int32.TryParse(selected, out mode);

                if (mode != 1 && mode != 2 && mode != 3)
                {
                    Console.WriteLine("{0}Такого режима не существует. Пожалуйста, выберите '1' или '2'{0}", Environment.NewLine);
                }
            }
            while (mode != 1 && mode != 2 && mode != 3);

            return mode;
        }
    }
}
