using System;
using System.Collections.Generic;

namespace DAL.Data
{
    public partial class Profile
    {
        public Profile()
        {
            Shows = new HashSet<Show>();
        }

        public int ProfileId { get; set; }
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;

        public virtual ICollection<Show> Shows { get; set; }
    }
}
