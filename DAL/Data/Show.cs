using System;
using System.Collections.Generic;

namespace DAL.Data
{
    public partial class Show
    {
        public int ShowId { get; set; }
        public int ProfileId { get; set; }
        public string ImdbId { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string TitleType { get; set; } = null!;
        public long ReleasedYear { get; set; }
        public string? ImageUrl { get; set; }
        public int? RunningTimeInMinutes { get; set; }
        public string? NextEpisodeId { get; set; }
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

        public virtual Profile Profile { get; set; } = null!;
    }
}
