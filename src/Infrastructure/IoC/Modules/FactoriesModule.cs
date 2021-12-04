using Autofac;
using Core.Commons.Factories;
using Core.Factories;
using System.Reflection;

namespace Infrastructure.IoC.Modules
{
    public class FactoriesModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var assembly = typeof(IFactory).GetTypeInfo().Assembly;

            builder.RegisterAssemblyTypes(assembly)
                .Where(x => x.IsAssignableTo<IFactory>())
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }
    }
}
