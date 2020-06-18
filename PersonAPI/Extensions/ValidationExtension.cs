using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;

namespace PersonAPI.Extensions
{
    public static class ValidationExtension
    {
        public static void SetupFluentValidation(this IServiceCollection services)
        {
            services
                .AddMvc()
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<Startup>());
        }
    }
}
