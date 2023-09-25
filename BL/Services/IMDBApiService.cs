using BL.Interface;
using BL.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services
{
    public class IMDBApiService : IIMDBApiService
    {
        private readonly IIMDBApi _IMDBApi;
        public IMDBApiService(IIMDBApi iMDBApi) 
        {
            _IMDBApi = iMDBApi;
        }

        public async Task<IEnumerable<results>> GetShowsAsync(string searchKey)
        {
            var result = await _IMDBApi.GetShowAsync("/title/find?q=" + searchKey);

            return result.results.Select(x => new results
            {
                id = x.id,
                image = x.image,
                runningTimeInMinutes = x.runningTimeInMinutes,
                nextEpisode = x.nextEpisode,
                numberOfEpisodes = x.numberOfEpisodes,
                seriesStartYear = x.seriesStartYear,
                title = x.title,
                season = x.season,
                episode = x.episode,
                titleType = x.titleType,
                year = x.year,
                parentTitle = x.parentTitle,

            }).ToList(); 
        }
    }
}
