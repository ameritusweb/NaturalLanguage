using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace NaturalLanguageProcess
{
    public class ListStringToSerializableWordConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return typeof(List<SerializableWord>).IsAssignableFrom(objectType);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JArray array = JArray.Load(reader);
            var result = new List<SerializableWord>();
            foreach (var item in array)
            {
                result.Add(new SerializableWord { SerializedWord = item.ToString() });
            }
            return result;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var words = value as List<SerializableWord>;
            writer.WriteStartArray();
            foreach (var word in words)
            {
                writer.WriteValue(word.SerializedWord);
            }
            writer.WriteEndArray();
        }
    }
}
