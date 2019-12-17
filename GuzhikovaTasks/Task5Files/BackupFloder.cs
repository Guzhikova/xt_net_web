using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5Files
{
    class BackupFloder
    {
        public BackupFloder()
        {
            Info = new DirectoryInfo(_path + _name);
            CreateIfNotExist();

        }

        private string _name = "BACKUP";
        private string _path = AppDomain.CurrentDomain.BaseDirectory;
        public DirectoryInfo Info { get; }


        public List<FileInfo> TxtFiles { get => GetTxtFiles(); }

        private void CreateIfNotExist()
        {
            try
            {
                if (!Info.Exists)
                {
                    Info.Create();

                    Console.WriteLine("Created " + Info.FullName);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("The process failed: {0}{1}{2}", ex.Message, Environment.NewLine, ex.StackTrace);
            }
        }

        private List<FileInfo> GetTxtFiles()
        {
            List<FileInfo> files = new List<FileInfo>();

            try
            {
                files = (Info.EnumerateFiles("*.txt")).ToList();

                var directories = Info.EnumerateDirectories("*", SearchOption.AllDirectories);

                foreach (var directory in directories)
                {
                    files.AddRange(directory.EnumerateFiles("*.txt"));
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("The process failed: {0}{1}{2}", ex.Message, Environment.NewLine, ex.StackTrace);
            }
            return files;
        }


    }
}
