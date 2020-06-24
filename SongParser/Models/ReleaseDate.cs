using Newtonsoft.Json;
using System;

namespace SongParser.Models
{
    public class ReleaseDate
    {
        [JsonProperty("full_date")] public DateTime FullDate { get; set; }
        [JsonProperty("year")] public int year { get; set; }
        [JsonProperty("month")] public int month { get; set; }
        [JsonProperty("day")] public int day { get; set; }
    }
}