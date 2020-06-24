using SongParser.Models;
using System.Collections.Generic;

namespace SongParser
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var songs = IOUtils.JsonDeserializeFromPath<List<Song>>(args[0]);
        }
    }
}