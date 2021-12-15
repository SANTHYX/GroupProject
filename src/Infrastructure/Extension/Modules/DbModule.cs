using Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Extension.Modules
{
    public static class DbModule
    {
        internal static IServiceCollection AddDbModule(this IServiceCollection services, IConfiguration configuration)
            => services.AddDbContext<DataContext>(x =>
            {
                x.UseNpgsql(configuration.GetConnectionString("MovieDbConnection"),
                    opt => opt.MigrationsAssembly("Infrastructure"));
                x.EnableDetailedErrors();
            });
    }
}
