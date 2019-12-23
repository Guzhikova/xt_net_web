using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5Files
{
    class FileData
    {
        public FileData() { }
        public FileData(FileInfo file)
        {
            Name = file.Name;
            FullName = file.FullName;
            Path = file.DirectoryName;
            CreationTime = file.CreationTime;
            Extension = file.Extension;
            LastAccessTime = file.LastAccessTime;
            LastWriteTime = file.LastWriteTime;
            Content = ReadFileContent(file);
            Attributes = file.Attributes;
        }

        public string Name { get; set; }
        public string FullName { get; set; }
        public string Path { get; set; }
        public string Content { get; set; }
        public DateTime CreationTime { get; set; }
        public FileAttributes Attributes { get; set; }
        public string Extension { get; set; }
        public DateTime LastAccessTime { get; set; }
        public DateTime LastWriteTime { get; set; }


        public void CreateFile()
        {
            try
            {
                FileInfo fileInfo = new FileInfo(FullName);
                fileInfo.Create().Close();

                fileInfo.CreationTime = CreationTime;
                fileInfo.LastAccessTime = LastAccessTime;
                fileInfo.LastWriteTime = LastWriteTime;

                using (Stream stream = File.Open(fileInfo.FullName, FileMode.OpenOrCreate, FileAccess.Write, FileShare.ReadWrite))
                {
                    using (StreamWriter writer = new StreamWriter(stream, System.Text.Encoding.Default))
                    {
                        writer.Write(Content);
                    }
                }

                fileInfo.Attributes = Attributes;
            }
            catch (Exception ex)
            {
                Console.WriteLine("The process failed: {0}{1}{2}", ex.Message, Environment.NewLine, ex.StackTrace);
            }
        }

        string ReadFileContent(FileInfo file)
        {
            string content = "";

            try
            {
                using (Stream stream = File.Open(file.FullName, FileMode.OpenOrCreate, FileAccess.Read, FileShare.ReadWrite))
                {
                    using (StreamReader reader = new StreamReader(stream, System.Text.Encoding.Default))
                    {
                        content = reader.ReadToEnd();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("The process failed: {0}{1}{2}", ex.Message, Environment.NewLine, ex.StackTrace);
            }
            return content;
        }

    }
}
