using Application.Commons.Services;
using Autofac;
using Core.Commons.Security;
using Infrastructure.Commons.Services;
using Infrastructure.Security;
using Infrastructure.Security.Services;
using Microsoft.AspNetCore.Http;

namespace Infrastructure.IoC.Modules
{
    public class SecurityModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<Encryptor>()
                .As<IEncryptor>()
                .SingleInstance();

            builder.RegisterType<IdentityService>()
                .As<IIdentityService>()
                .InstancePerLifetimeScope();

            builder.RegisterType<JwtService>()
                .As<IJwtService>()
                .InstancePerLifetimeScope();

            builder.RegisterType<HttpContextAccessor>()
                .As<IHttpContextAccessor>()
                .SingleInstance();
        }
    }
}
