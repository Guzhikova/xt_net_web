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
            BackupFloder mainFloder = new BackupFloder();
            List<FileInfo> txtFiles = mainFloder.TxtFiles;
            Console.WriteLine(mainFloder.Info.FullName);
            Show(txtFiles);

            Watcher watcher = new Watcher();
            watcher.Run(mainFloder.Info.FullName);

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
