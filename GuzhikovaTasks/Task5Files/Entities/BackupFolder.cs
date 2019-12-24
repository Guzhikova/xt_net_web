using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5Files
{
    internal class BackupFolder
    {
        private string _name = "BACKUP";
        private string _path = AppDomain.CurrentDomain.BaseDirectory;

        public BackupFolder()
        {
            Info = new DirectoryInfo(_path + _name);
            CreateIfNotExist();
        }

        public DirectoryInfo Info { get; }
        public List<FileData> TxtFiles
        {
            get
            {
                List<FileInfo> fileInfoList = GetFilesByExtension("txt");
                return ConvertFileInfoToFileDataList(fileInfoList);
            }
        }

        private void CreateIfNotExist()
        {
            try
            {
                if (!Info.Exists)
                {
                    Directory.CreateDirectory(Info.FullName);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("The process failed: {0}{1}{2}", ex.Message, Environment.NewLine, ex.StackTrace);
            }
        }
        private List<FileInfo> GetFilesByExtension(string extension)
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
        private List<FileData> ConvertFileInfoToFileDataList(List<FileInfo> fileInfoList)
        {
            List<FileData> fileDataList = new List<FileData>();

            try
            {
                foreach (var fileInfo in fileInfoList)
                {
                    FileData fileData = new FileData(fileInfo);
                    fileDataList.Add(fileData);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("The process failed: {0}{1}{2}", ex.Message, Environment.NewLine, ex.StackTrace);
            }
            return fileDataList;
        }

    }
}
