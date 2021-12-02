using Application.Commons.Validators.Identity;
using Core.Types;
using FluentValidation.AspNetCore;
using Infrastructure.Options;
using Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Extension
{
    public static class InfrastructureExtension
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<SecuritySettings>(configuration.GetSection(SecuritySettings.Section));
            services.AddDbContext<DataContext>(x => 
            {
                x.UseNpgsql(configuration.GetConnectionString("MovieDbConnection"),
                    opt => opt.MigrationsAssembly("Infrastructure"));
                x.EnableDetailedErrors();
            });
            services.AddFluentValidation(cfg =>
                cfg.RegisterValidatorsFromAssemblyContaining<IValidator>());
        }
    }
}
