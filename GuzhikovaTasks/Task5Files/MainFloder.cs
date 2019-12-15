using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5Files
{
    class MainFloder : BackupObject
    {
        public MainFloder()
        {
            MainDirectory = new DirectoryInfo(_path + _name);

            CreateIfNotExist();

        }

        private string _name = "BACKUP";
        private string _path = AppDomain.CurrentDomain.BaseDirectory;
        protected DirectoryInfo MainDirectory { get; }


        public List<FileInfo> TxtFiles { get => GetTXT(); }

        public override string Name { get => MainDirectory.Name; }
        public override string Path { get => MainDirectory.FullName; }

        //private int myVar;

        //public int MyProperty
        //{
        //    get { return myVar; }
        //    set { myVar = value; }
        //}


        void CreateIfNotExist()
        {
            try
            {

                if (!MainDirectory.Exists)
                {
                    MainDirectory.Create();

                    Console.WriteLine("Created " + MainDirectory.FullName);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("The process failed: {0}{1}{2}", ex.Message, Environment.NewLine, ex.StackTrace);
            }
        }

        List<FileInfo> GetTXT()
        {
            List<FileInfo> files = new List<FileInfo>();

            try
            {
                files = (MainDirectory.EnumerateFiles("*.txt")).ToList();

                var directories = MainDirectory.EnumerateDirectories("*", SearchOption.AllDirectories);

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
