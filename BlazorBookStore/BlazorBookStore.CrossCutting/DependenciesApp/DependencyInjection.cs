using BlazorBookStore.Domain.Abstractions;
using BlazorBookStore.Infrastructure.Context;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using BlazorBookStore.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BlazorBookStore.CrossCutting.DependenciesApp
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("SqlServer");

            services.AddDbContext<AppDbContext>(opt =>
            {
                opt.UseSqlServer(connectionString);
            });

            services.AddScoped<IBookRepository, BookRepository>();

            return services;
        }
    }
}
