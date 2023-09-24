using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace BL.Utility
{
    public class IMDBApi : IIMDBApi
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public readonly IConfiguration _configuration;

        public IMDBApi(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
        }

        public async Task<IMDBApiResponses> GetShowAsync(string endpoint)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, endpoint);
            request.Headers.Add("X-RapidAPI-Key", _configuration["ApiKey"]);

            var result = await _httpClientFactory.CreateClient(ApiConstants.IMDBApi).SendAsync(request);
            if(!result.IsSuccessStatusCode)
                throw new Exception(result.StatusCode.ToString());
            
            var body = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<IMDBApiResponses>(body);
        }
    }
}
