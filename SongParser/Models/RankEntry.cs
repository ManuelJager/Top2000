using Newtonsoft.Json;

namespace SongParser.Models
{
    public class RankEntry
    {
        [JsonProperty("year")] public int Year { get; set; }
        [JsonProperty("rank")] public int Rank { get; set; }
    }
}