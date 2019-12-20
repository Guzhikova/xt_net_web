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
                using (FileStream fs = File.Create(_path))
                {
                }

                //SaveToJsonFile(someObject);
            }
        }

        private string _path = "";
        public string Path { get => _path; }
        public void SaveToJsonFile(T someObject)
        {
          
            using (StreamWriter fs = new StreamWriter(Path))
            {
                string jsonString = JsonConvert.SerializeObject(someObject);

                jsonString = JObject.Parse(jsonString).ToString(Newtonsoft.Json.Formatting.Indented);
                fs.Write(jsonString);
            }
        }

        public T ReadFromJsonFile()
        { 
            if (!File.Exists(Path))
            {
                throw new FileNotFoundException($"ERROR! This file does not exist.");
            }
            return JsonConvert.DeserializeObject<T>(File.ReadAllText(Path));
        }


        //public void SaveToJsonFile<T>(string fullName, T someObject)
        //{
        //    if (!File.Exists(fullName))
        //    {
        //        using (FileStream fs = File.Create(fullName))
        //        {
        //        }
        //    }


        //    using (StreamWriter fs = new StreamWriter(fullName))
        //    {
        //        string jsonString = JsonConvert.SerializeObject(someObject);

        //        jsonString = JObject.Parse(jsonString).ToString(Newtonsoft.Json.Formatting.Indented);
        //        fs.Write(jsonString);
        //    }
        //}

        //public T ReadFromJsonFile<T>(string fullName)
        //{
        //    if (!File.Exists(fullName))
        //    {
        //        throw new FileNotFoundException($"ERROR! This file does not exist.");
        //    }

        //    return JsonConvert.DeserializeObject<T>(File.ReadAllText(fullName));
        //}
    }
}
