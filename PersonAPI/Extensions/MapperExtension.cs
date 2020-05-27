using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using PersonAPI.Profiles;

namespace PersonAPI
{
    public static class MapperExtension
    {
        public static void SetupMapper(this IServiceCollection services)
        {
            var configuration = new MapperConfiguration((cfg) => 
            {
                cfg.AddProfile<PersonProfile>();
                cfg.AddProfile<CommonProfile>();
            });

            var mapper = configuration.CreateMapper();

            services.AddSingleton(mapper);
        }
    }
}
