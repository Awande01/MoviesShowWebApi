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
        public string Title { get; set; }
        public long ReleaseYear { get; set; }
        public string ImdbId { get; set; }
        public string Type { get; set; }
        public string Poster { get; set; }
        public string Genre { get; set; }
        public bool IsWatched { get; set; }
    }
}
