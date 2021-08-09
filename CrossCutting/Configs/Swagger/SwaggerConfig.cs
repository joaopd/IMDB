using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System.Collections.Generic;

namespace CrossCutting.Swagger
{
    public static class SwaggerConfig
    {
        public static IServiceCollection SwaggerConfigGen(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Api Fimes",
                    Description = "Arquitetura DDD",
                    Contact = new OpenApiContact
                    {
                        Name = "João Pedro Correia",
                        Email = "jpkabral@live.com"
                    }
                });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "Entre com Token JWT",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                  {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                          Id = "Bearer",
                          Type = ReferenceType.SecurityScheme
                        }
                    }, new List<string>()
                  }
                });
            });

            return services;
        }
    }
}
