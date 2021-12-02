using Application.Identity.Commands.ChangeCreedentials;
using Application.Identity.Commands.LoginUser;
using Application.Identity.Commands.RecoveryAccess;
using Application.Identity.Commands.RefreshToken;
using Application.Identity.Commands.RegisterUser;
using Application.Identity.Commands.RevokeToken;
using Application.Identity.Commands.SetPasswordAtRecovery;
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
            services.AddOptions<SecuritySettings>(configuration.GetSection(SecuritySettings.Section).Value);
            services.AddDbContext<DataContext>(x => 
            {
                x.UseNpgsql(configuration.GetConnectionString("MovieDbConnection"),
                    opt => opt.MigrationsAssembly("Infrastructure"));
                x.EnableDetailedErrors();
            });
            services.AddFluentValidation(cfg =>
            {    
                cfg.RegisterValidatorsFromAssemblyContaining<SignUp>();
                cfg.RegisterValidatorsFromAssemblyContaining<SignIn>();
                cfg.RegisterValidatorsFromAssemblyContaining<SetPasswordAtRecovery>();
                cfg.RegisterValidatorsFromAssemblyContaining<RevokeToken>();
                cfg.RegisterValidatorsFromAssemblyContaining<RefreshToken>();
                cfg.RegisterValidatorsFromAssemblyContaining<RecoveryAccess>();
                cfg.RegisterValidatorsFromAssemblyContaining<ChangeCreedentials>();
            }).AddFluentValidation();
                
                
        }
    }
}
