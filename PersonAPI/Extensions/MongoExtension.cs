using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using PersonAPI.Settings;

namespace PersonAPI.Extensions
{
    public static class MongoExtension
    {
        public static void SetupMongo(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<MongoSettings>(
                configuration.GetSection(nameof(MongoSettings))
            );

            services.AddSingleton<IMongoSettings>((op) => 
            {
                return op.GetRequiredService<IOptions<MongoSettings>>().Value;
            });
        }
    }
}
