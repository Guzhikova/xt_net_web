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
    class JsonAdapter
    {
        public void SaveToJsonFile<T>(string fullName, T someObject)
        {
            if (!File.Exists(fullName))
            {
                using (FileStream fs = File.Create(fullName))
                {
                }
            }





            using (StreamWriter fs = new StreamWriter(fullName))
            {
                string jsonString = JsonConvert.SerializeObject(someObject);

                jsonString = JObject.Parse(jsonString).ToString(Newtonsoft.Json.Formatting.Indented);
                fs.Write(jsonString);
            }
        }

        public T ReadFromJsonFile<T>(string fullName, T someObject)
        {
            if (!File.Exists(fullName))
            {
                throw new FileNotFoundException($"ERROR! This file does not exist.");
            }

            return JsonConvert.DeserializeObject<T>(File.ReadAllText(fullName));
        }
    }
}
