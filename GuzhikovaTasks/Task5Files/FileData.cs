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
            CreatingDate = file.CreationTime;
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
        public DateTime CreatingDate { get; }
        public FileAttributes Attributes { get; set; }
        public string Extension { get; set; }
        public DateTime LastAccessTime { get; set; }
        public DateTime LastWriteTime { get; set; }

        private static object _fileLock = new Object();
        string ReadFileContent(FileInfo file)
        {
            string content = "";

                using (Stream stream = File.Open(file.FullName, FileMode.OpenOrCreate, FileAccess.Read, FileShare.ReadWrite))
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        content = reader.ReadToEnd();
                    }
                }

            return content;
        }

    }
}
