using DAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface
{
    public interface IShowRepository
    {
        Task<Show> GetShowByImdbId(string imdbId);
        Task<List<Show>> GetShowByProfileId(int ProfileId);
        Task SaveShow(Show showObj);
        Task<bool> DeleteShow(int showId);
        Task<bool> UpdateShow(int showId, bool isWatched);
    }
}
