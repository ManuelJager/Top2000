using Newtonsoft.Json;
using System.Collections.Generic;

namespace SongParser.Models
{
    public class Song
    {
        [JsonProperty("title")] public string Title { get; set; }
        [JsonProperty("full_artist")] public string FullArtist { get; set; }
        [JsonProperty("rank_entries")] public List<RankEntry> RankEntries { get; set; }
        [JsonProperty("genres")] public List<string> Genres { get; set; }
        [JsonProperty("artists")] public List<string> Artists { get; set; }
        [JsonProperty("release_date")] public ReleaseDate ReleaseDate { get; set; }
        [JsonProperty("images")] public List<Image> Images { get; set; }
        [JsonProperty("preview_url", Required = Required.AllowNull)] public string PreviewUrl { get; set; }
    }
}