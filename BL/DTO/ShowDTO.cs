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
        public long? ReleasedYear { get; set; }
        public string ImdbId { get; set; } 
        public string Type { get; set; } 
        public string ImageUrl { get; set; } = string.Empty;
        public int? RunningTimeInMinutes { get; set; }
        public int? NextEpisodeId { get; set; } 
        public int? NumberOfEpisodes { get; set; }
        public bool? IsWatched { get; set; }
    }
}
