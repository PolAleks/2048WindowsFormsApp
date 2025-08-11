using Newtonsoft.Json;

namespace _2048.Common
{
    public class JsonConverter : IConverter
    {
        public T Deserialize<T>(string data)
        {
            return JsonConvert.DeserializeObject<T>(data);
        }

        public string Serialize<T>(T item)
        {
            return JsonConvert.SerializeObject(item, Formatting.Indented);
        }
    }
}
