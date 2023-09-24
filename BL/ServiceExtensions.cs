using BL.Utility;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualBasic;

namespace BL
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddApiService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IIMDBApi, IMDBApi>();
            services.AddHttpClient(ApiConstants.IMDBApi, x =>
            {
                x.BaseAddress = new Uri(configuration["IMDBApiUrl"]);
            });

            return services;
        }
    }
}