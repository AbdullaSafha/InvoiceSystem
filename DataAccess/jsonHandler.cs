using InvoiceSystem.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Xml;
using Newtonsoft.Json;

namespace InvoiceSystem.DataAccess
{
    public class JsonHandler
    {
        //Read
        //write
        internal void WriteToFile<T>(string filePath, List<T> data)
        {
            var json = JsonConvert.SerializeObject(data, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(filePath, json);
            //throw new NotImplementedException();
        }

        internal List<T> ReadFromFile<T>(string filePath)
        {
            if (!File.Exists(filePath))
            {
                return new List<T>();
            }

            var json = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<List<T>>(json);
        }
    }
}
