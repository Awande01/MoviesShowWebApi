using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Utility
{
    public class IMDBApiResponses
    {
        public List<results> results { get; set; } 

    }
    public class results
    {
        public string id { get; set; }
        public image image { get; set; } = new image();
        public int runningTimeInMinutes { get; set; }
        public string nextEpisode { get; set; } = string.Empty;
        public int numberOfEpisodes { get; set; }
        public long seriesStartYear { get; set; }
        public string title { get; set; } = string.Empty;
        public int season { get; set; }
        public int episode { get; set; }
        public string titleType { get; set; } = string.Empty;
        public long year { get; set; }
        public parentTitle parentTitle { get; set; } = new parentTitle();
    }
    public class image
    {
        public int? height { get; set; }
        public string id { get; set; } = string.Empty;
        public string url { get; set; } = string.Empty;
        public int? width { get; set; }
    }
    public class parentTitle
    {
        public image image { get; set; } = new image();
        public string titleType { get; set; } = string.Empty;
        public string title { get; set; } = string.Empty;
        public long? year { get; set; }
        public string id { get; set; } = string.Empty;

    }
}

