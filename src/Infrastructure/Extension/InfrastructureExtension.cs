using Application.Commons.Validators.Identity;
using FluentValidation.AspNetCore;
using Infrastructure.Extension.Modules;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Extension
{
    public static class InfrastructureExtension
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddOptionsModule(configuration);
            services.AddDbModule(configuration);
            services.AddFluentValidation(cfg =>
                cfg.RegisterValidatorsFromAssemblyContaining<SignUpValidator>());
            services.AddSwaggerGenNewtonsoftSupport();
            services.AddJwtAuthenticationModule(configuration);
        }
    }
}
