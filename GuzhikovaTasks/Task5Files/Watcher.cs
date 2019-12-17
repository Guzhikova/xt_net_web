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
      
        public  void Run(string path)
        {
           
            using (FileSystemWatcher watcher = new FileSystemWatcher())
            {
                watcher.Path = path;

                watcher.NotifyFilter = NotifyFilters.LastWrite
                                     | NotifyFilters.FileName
                                     | NotifyFilters.DirectoryName;

                watcher.Filter = "*.txt";

                watcher.Changed += OnChanged;
                watcher.Created += OnChanged;
                watcher.Deleted += OnChanged;
                watcher.Renamed += OnRenamed;

                watcher.EnableRaisingEvents = true;

                Console.WriteLine("Press 'q' to quit the sample.");
                while (Console.Read() != 'q') ;
            }
        }

        private static void OnRenamed(object sender, RenamedEventArgs e)
        {
            Console.WriteLine(e.Name + e.ChangeType);
        }

        private static void OnChanged(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine(e.Name + e.ChangeType);
        }
    }
}

