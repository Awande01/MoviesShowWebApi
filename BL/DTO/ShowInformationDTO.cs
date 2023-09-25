using BL.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.DTO
{
    public class ShowInformationDTO
    {
        public int ProfileId { get; set; }
        public string id { get; set; }
        public image image { get; set; } = new image();
        public int? RunningTimeInMinutes { get; set; }
        public string NextEpisode { get; set; } = string.Empty;
        public int NumberOfEpisodes { get; set; }
        public string Title { get; set; } = string.Empty;
        public int? Season { get; set; }
        public int? Episode { get; set; }
        public string TitleType { get; set; } = string.Empty;
        public long Year { get; set; }
        public parentTitle ParentTitle { get; set; } = new parentTitle();
        public bool? IsWatched { get; set; }
    }
}
