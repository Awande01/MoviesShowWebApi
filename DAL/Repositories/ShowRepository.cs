using DAL.Data;
using DAL.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class ShowRepository: IShowRepository
    {
        private readonly TestingDatabaseContext _databaseContext;
        public ShowRepository(TestingDatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task<Show> GetShowByImdbId(string imdbId)
        {
            return await _databaseContext.Shows.FirstOrDefaultAsync(x => x.ImdbId == imdbId);

        }
        public async Task<List<Show>> GetShowByProfileId(int ProfileId)
        {
            var shows = await _databaseContext.Shows.Where(x => x.ProfileId == ProfileId).ToListAsync();
            return shows;
        }
        public async Task SaveShow(Show showObj)
        {
           _databaseContext.Add(showObj);
           await _databaseContext.SaveChangesAsync();
        }
        public async Task<bool> DeleteShow(int showId)
        {
            var show = await _databaseContext.Shows.FirstOrDefaultAsync(x => x.ShowId == showId);
            if (show != null)
            {

                _databaseContext.Remove(show);
                _databaseContext.SaveChanges();
            }

            return show != null;
        }
        public async Task<bool> UpdateShow(int showId , bool isWatched)
        {
            var show = await _databaseContext.Shows.FirstOrDefaultAsync(x => x.ShowId == showId);
            if (show != null)
            {
                show.IsWatched = isWatched;
                await _databaseContext.SaveChangesAsync();
            }
            return show != null;
        }

    }
}
