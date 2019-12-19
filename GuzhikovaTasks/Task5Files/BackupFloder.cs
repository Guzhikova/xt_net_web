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
        public List<FileData> TxtFiles
        {
            get
            {
                List<FileInfo> fileInfoList = GetFilesByExtension("txt");
                return ConvertFileInfoToFileDataList(fileInfoList);
            }
        }

        void CreateIfNotExist()
        {
            try
            {
                if (!Info.Exists)
                {
                    Info.Create();

                    Console.WriteLine("Successfully created: " + Info.FullName);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("The process failed: {0}{1}{2}", ex.Message, Environment.NewLine, ex.StackTrace);
            }
        }

        //уточнить из какой папки берет
        List<FileInfo> GetFilesByExtension(string extension)
        {
            List<FileInfo> files = new List<FileInfo>();

            try
            {
                files = (Info.EnumerateFiles($"*.{extension}")).ToList();

                var directories = Info.EnumerateDirectories("*", SearchOption.AllDirectories);

                foreach (var directory in directories)
                {
                    files.AddRange(directory.EnumerateFiles($"*.{extension}"));
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("The process failed: {0}{1}{2}", ex.Message, Environment.NewLine, ex.StackTrace);
            }
            return files;
        }

        List<FileData> ConvertFileInfoToFileDataList(List<FileInfo> fileInfoList)
        {
            List<FileData> fileDataList = new List<FileData>();

            foreach (var fileInfo in fileInfoList)
            {
                FileData fileData = new FileData(fileInfo);
                fileDataList.Add(fileData);
            }
            return fileDataList;
        }

        //private List<FileInfo> GetFilesByType(string type)
        //{
        //    List<FileInfo> files = new List<FileInfo>();

        //    try
        //    {
        //        files = (Info.EnumerateFiles($"*.{type}")).ToList();

        //        var directories = Info.EnumerateDirectories("*", SearchOption.AllDirectories);

        //        foreach (var directory in directories)
        //        {
        //            files.AddRange(directory.EnumerateFiles($"*.{type}"));
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("The process failed: {0}{1}{2}", ex.Message, Environment.NewLine, ex.StackTrace);
        //    }
        //    return files;
        //}
    }
}
