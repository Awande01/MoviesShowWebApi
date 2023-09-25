using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.DTO
{
    public class ShowDTO
    {
        public int ShowId { get; set; }
        public string Title { get; set; } 
        public long? Year { get; set; }
        public string ImdbId { get; set; } 
        public string Type { get; set; } 
        public string ImageUrl { get; set; } = string.Empty;
        public int? RunningTimeInMinutes { get; set; }
        public string NextEpisodeId { get; set; } = string.Empty;
        public int? NumberOfEpisodes { get; set; }
        public bool? IsWatched { get; set; }
        public int? Episode { get; set; }
        public int? Season { get; set; }
        public string? ParentImdbId { get; set; }
        public string? ParentTitle { get; set; }
        public string? ParentTitleType { get; set; }
        public string? ParentImageUrl { get; set; }
        public long? ParentReleasedYear { get; set; }
        public int? EpisodeNumber { get; set; }
    }
}
