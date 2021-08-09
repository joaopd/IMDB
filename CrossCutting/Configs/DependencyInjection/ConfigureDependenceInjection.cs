using Data;
using Data.Interfaces;
using Data.Repositorio;
using Domain.Models.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CrossCutting.DependenyIntection
{
    public static class ConfigureDependenceInjection
    {
        public static void ConfigureDependence(this IServiceCollection services, IConfiguration configuration)
        {
            ConfigureGenericRepositoy(services);
            ConfigureProdutoRepositoy(services);
            ConfigureEmployeeRepositoy(services);
            ConfigureMovieRepositoy(services);


            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        }

        public static void ConfigureGenericRepositoy(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        }
        public static void ConfigureProdutoRepositoy(this IServiceCollection services)
        {
            services.AddScoped<IProdutos, ProdutosRepository>();
        }
        public static void ConfigureEmployeeRepositoy(this IServiceCollection services)
        {
            services.AddScoped<IEmployee, EmployeeRepository>();
        }
        public static void ConfigureMovieRepositoy(this IServiceCollection services)
        {
            services.AddScoped<IMovie, MovieRepository>();
        }
    }
}
