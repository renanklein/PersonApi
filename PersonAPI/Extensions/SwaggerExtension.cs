using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Reflection;

namespace PersonAPI.Extensions
{
    public static class SwaggerExtension
    {
        public static void SetupSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(options => 
            {
                options.SwaggerDoc("v1", new OpenApiInfo 
                {
                    Title = "PersonApi",
                    Description = "A simple REST Api for training purpose",
                    Contact = new OpenApiContact
                    {
                        Name = "Renan Ferreira Klein",
                        Url = new Uri("https://github.com/renanklein")
                    }
                });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                options.IncludeXmlComments(xmlPath);
            });

            services.AddSwaggerGenNewtonsoftSupport();


        }
    }
}
