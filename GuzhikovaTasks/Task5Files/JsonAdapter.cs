using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Task5Files
{
    class JsonAdapter<T>
    {
        public JsonAdapter()
        {
            BackupFolder mainFloder = new BackupFolder();
            _path = $"{mainFloder.Info.FullName}\\Log.json";

            if (!File.Exists(_path))
            {
                File.Create(_path).Close();

                //SaveToJsonFile(someObject);
            }
        }

        private string _path = "";
        public string Path { get => _path; }
        private Stream _stream;
        private static object _fileLock = new Object();

        public void SaveToJsonFile(T someObject)
        {
            string jsonString = JsonConvert.SerializeObject(someObject);
            jsonString = JObject.Parse(jsonString).ToString(Newtonsoft.Json.Formatting.Indented);

                using (_stream = File.Open(Path, FileMode.OpenOrCreate, FileAccess.Write, FileShare.ReadWrite))
                {
                using (StreamWriter writer = new StreamWriter(_stream, System.Text.Encoding.Default))
                {
                        writer.Write(jsonString);
                    }
                }
            
        }

        public T ReadFromJsonFile()
        {
            if (!File.Exists(Path))
            {
                throw new FileNotFoundException($"ERROR! This file does not exist.");
            }
            string content = "";

                using (_stream = File.Open(Path, FileMode.OpenOrCreate, FileAccess.Read, FileShare.ReadWrite))
                {
                    using (StreamReader reader = new StreamReader(_stream, System.Text.Encoding.Default))
                    {
                        content = reader.ReadToEnd();
                    }
                }
            

            return JsonConvert.DeserializeObject<T>(content);
        }
    }
}
