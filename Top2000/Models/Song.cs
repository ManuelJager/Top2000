using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Top2000.Models
{
    public class Song
    {
        public string Title { get; set; }
        public string FullArtist { get; set; }
        public List<RankEntry> RankEntries { get; set; }
        public List<string> Genres { get; set; }
        public List<string> Artists { get; set; }
        public ReleaseDate ReleaseDate { get; set; }
        public string PreviewUrl { get; set; }
    }
}
