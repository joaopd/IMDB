using Infrastructure.Context;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Threading.Tasks;

namespace CrossCutting.Configs.Security
{
    public static class ConfigAuth
    {
        public static void AddIdentityConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AuthDbContext>(options =>
              options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
         .AddJwtBearer(option =>
         {
             option.TokenValidationParameters = new TokenValidationParameters
             {
                 ValidateIssuer = false,
                 ValidateAudience = false,
                 ValidateLifetime = true,
                 ValidateIssuerSigningKey = true,

                 ValidIssuer = "Teste.Securiry.Bearer",
                 ValidAudience = "Teste.Securiry.Bearer",
                 IssuerSigningKey = JwtSecurityKey.Create("Secret_Key-12345678")
             };

             option.Events = new JwtBearerEvents
             {
                 OnAuthenticationFailed = context =>
                 {
                     Console.WriteLine("OnAuthenticationFailed: " + context.Exception.Message);
                     return Task.CompletedTask;
                 },
                 OnTokenValidated = context =>
                 {
                     Console.WriteLine("OnTokenValidated: " + context.SecurityToken);
                     return Task.CompletedTask;
                 }
             };
         });
        }
    }
}
