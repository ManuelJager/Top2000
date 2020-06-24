using Newtonsoft.Json;
using System.IO;

namespace SongParser
{
    public static class IOUtils
    {
        public static JsonSerializerSettings systemJsonSettings = new JsonSerializerSettings
        {
            Formatting = Formatting.None,
            DefaultValueHandling = DefaultValueHandling.Ignore
        };

        public static JsonSerializerSettings userJsonSettings = new JsonSerializerSettings
        {
            Formatting = Formatting.Indented,
            DefaultValueHandling = DefaultValueHandling.Ignore
        };

        public static T JsonDeserializeFromPath<T>(string filePath)
        {
            var text = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<T>(text, systemJsonSettings);
        }
    }
}