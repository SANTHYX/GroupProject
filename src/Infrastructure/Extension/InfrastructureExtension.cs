using Application.Commons.Validators.Identity;
using FluentValidation.AspNetCore;
using Infrastructure.Options;
using Infrastructure.Persistance;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;

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
                cfg.RegisterValidatorsFromAssemblyContaining<SignUpValidator>());

            services.AddSwaggerGenNewtonsoftSupport();

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
               {
                   x.TokenValidationParameters = new TokenValidationParameters
                   {
                       ValidateIssuer = false,
                       ValidateAudience = false,
                       ValidateIssuerSigningKey = true,
                       RequireExpirationTime = true,
                       ValidateLifetime = true,
                       IssuerSigningKey = new SymmetricSecurityKey(
                           Encoding.UTF8.GetBytes(configuration.GetSection("AuToken:Key").Value)),
                       ClockSkew = TimeSpan.Zero
                   };
               });
        }
    }
}
