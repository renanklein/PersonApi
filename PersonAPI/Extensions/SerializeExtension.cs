using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Serialization;

namespace PersonAPI.Extensions
{
    public static class SerializeExtension
    {
        public static void SetupJsonSerializer(this IServiceCollection services)
        {
            services.AddControllers().AddNewtonsoftJson((options) => 
            {
                options.SerializerSettings.ContractResolver = new DefaultContractResolver
                {
                    NamingStrategy = new SnakeCaseNamingStrategy()
                };
                 
            });
        }
    }
}
