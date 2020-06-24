using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Top2000.ViewModels
{
    public class SongViewModel
    {
        public int Rank { get; set; }
        public string Title { get; set; }
        public List<string> Artists { get; set; }
        public int Year { get; set; }
    }
}