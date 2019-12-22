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

            _path = mainFloder.Info.FullName + System.IO.Path.DirectorySeparatorChar + "Log.json";

            if (!File.Exists(_path))
            {
                File.Create(_path).Close();
            }
        }

        private string _path = "";
        public string Path { get => _path; }
        private Stream _stream;

        public void SaveToJsonFile(T someObject)
        {
            try
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
            catch (Exception ex)
            {
                Console.WriteLine("The process failed: {0}{1}{2}", ex.Message, Environment.NewLine, ex.StackTrace);
            }

        }

        public T ReadFromJsonFile()
        {
            string content = "";
            try
            {
                using (_stream = File.Open(Path, FileMode.OpenOrCreate, FileAccess.Read, FileShare.ReadWrite))
                {
                    using (StreamReader reader = new StreamReader(_stream, System.Text.Encoding.Default))
                    {
                        content = reader.ReadToEnd();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("The process failed: {0}{1}{2}", ex.Message, Environment.NewLine, ex.StackTrace);
            }

            return JsonConvert.DeserializeObject<T>(content);
        }
    }
}
