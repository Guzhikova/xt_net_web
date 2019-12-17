using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Task5Files
{
    class JsonAdapter
    {
        public void SaveToJsonFile<T>(string fullName, T someObject)
        {
            if (!File.Exists(fullName))
            {
                File.Create(fullName);
            }

            string jsonString = JsonConvert.SerializeObject(someObject);
            File.WriteAllText(fullName, jsonString);
        }

        public T ReadFromJsonFile<T>(string fullName, T someObject)
        {
            if (!File.Exists(fullName))
            {
                throw new FileNotFoundException($"ERROR! This file does not exist.");
            }

          return  JsonConvert.DeserializeObject<T>(File.ReadAllText(fullName));
        }
    }
}
