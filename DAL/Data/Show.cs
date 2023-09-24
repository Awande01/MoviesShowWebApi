﻿using System;
using System.Collections.Generic;

namespace DAL.Data
{
    public partial class Show
    {
        public Show()
        {
            Episodes = new HashSet<Episode>();
        }

        public int ShowId { get; set; }
        public int ProfileId { get; set; }
        public string ImdbId { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string TitleType { get; set; } = null!;
        public long ReleasedYear { get; set; }
        public string? ImageUrl { get; set; }
        public int? RunningTimeInMinutes { get; set; }
        public int? NextEpisodeId { get; set; }
        public int? NumberOfEpisodes { get; set; }
        public bool? IsWatched { get; set; }

        public virtual Profile Profile { get; set; } = null!;
        public virtual ICollection<Episode> Episodes { get; set; }
    }
}
