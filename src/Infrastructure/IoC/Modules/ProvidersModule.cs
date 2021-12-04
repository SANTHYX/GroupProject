using Application.Commons.Providers;
using Autofac;
using Infrastructure.Providers;

namespace Infrastructure.IoC.Modules
{
    public class ProvidersModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ServerDetailsProvider>()
                .As<IServerDetailsProvider>()
                .InstancePerLifetimeScope();
        }
    }
}
