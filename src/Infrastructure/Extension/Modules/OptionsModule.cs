using Infrastructure.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Extension.Modules
{
    public static class OptionsModule
    {
        internal static IServiceCollection AddOptionsModule(this IServiceCollection services, IConfiguration configuration)
            => services.Configure<SecuritySettings>(configuration.GetSection(SecuritySettings.Section));
    }
}
