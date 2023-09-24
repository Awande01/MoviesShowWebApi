using System;
using System.Collections.Generic;

namespace DAL.Data
{
    public partial class Show
    {
        public int ShowId { get; set; }
        public int ProfileId { get; set; }
        public string Title { get; set; } = null!;
        public long ReleaseYear { get; set; }
        public string ImdbId { get; set; } = null!;
        public string Type { get; set; } = null!;
        public string Poster { get; set; } = null!;
        public string Genre { get; set; } = null!;
        public bool IsWatched { get; set; }

        public virtual Profile Profile { get; set; } = null!;
    }
}
