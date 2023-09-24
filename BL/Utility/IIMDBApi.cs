using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Utility
{
    public  interface IIMDBApi
    {
        Task<IMDBApiResponses> GetShowAsync(string endpoint);
    }
}
