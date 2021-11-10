using Autofac;
using Infrastructure.IoC.Modules;

namespace Infrastructure.IoC
{
    public class InfrastructureIoC : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule<RepositoriesModule>();
            builder.RegisterModule<FactoriesModule>();
            builder.RegisterModule<CQRSModule>();
        }
    }
}
