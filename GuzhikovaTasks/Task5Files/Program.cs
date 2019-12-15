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
            MainFloder mainFloder = new MainFloder();
            List<FileInfo> txtFiles = mainFloder.TxtFiles;

            Show(txtFiles);

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
