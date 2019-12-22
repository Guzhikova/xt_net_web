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
            Attributes = file.Attributes;
            Extension = file.Extension;
            LastAccessTime = file.LastAccessTime;
            LastWriteTime = file.LastWriteTime;

            Content = ReadFileContent(file);
        }

        public string Name { get; set; }
        public string FullName { get; set; }
        public string Path { get; set; }
        public string Content { get; set; }
        public DateTime CreationTime { get; }
        public FileAttributes Attributes { get; set; }
        public string Extension { get; set; }
        public DateTime LastAccessTime { get; set; }
        public DateTime LastWriteTime { get; set; }


        public void CreateFile()
        {
            FileInfo fileInfo = new FileInfo(Path + "\\backup__" + Name);
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

        string ReadFileContent(FileInfo file)
        {
            string content = "";

            using (Stream stream = File.Open(file.FullName, FileMode.OpenOrCreate, FileAccess.Read, FileShare.ReadWrite))
            {
                using (StreamReader reader = new StreamReader(stream, System.Text.Encoding.Default))
                {
                    content = reader.ReadToEnd();
                }
            }

            return content;
        }

    }
}
