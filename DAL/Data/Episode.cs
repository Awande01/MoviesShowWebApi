using System;
using System.Collections.Generic;

namespace DAL.Data
{
    public partial class Episode
    {
        public int EpisodeId { get; set; }
        public int ShowId { get; set; }
        public string ImdbId { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string TitleType { get; set; } = null!;
        public long ReleasedYear { get; set; }
        public string? ImageUrl { get; set; }
        public int? RunningTimeInMinutes { get; set; }
        public string? NextEpisodeId { get; set; }
        public int? EpisodeNumber { get; set; }
        public int? Season { get; set; }
        public string? ParentImdbId { get; set; }
        public bool? IsWatched { get; set; }

        public virtual Show Show { get; set; } = null!;
    }
}
