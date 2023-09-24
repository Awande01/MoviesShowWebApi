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

        public async Task<IMDBApiResponses> GetShowsAsync(string searchKey)
        {
            var result = await _IMDBApi.GetShowAsync("/title/find?q=" + searchKey);
            return result;
        }
    }
}
