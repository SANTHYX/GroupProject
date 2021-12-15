using Application.Commons.Mappers;
using Autofac;
using System.Reflection;

namespace Infrastructure.IoC.Modules
{
    public class MappersModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var assembly = typeof(IMapper).GetTypeInfo().Assembly;

            builder.RegisterAssemblyTypes(assembly)
                .Where(x => x.IsAssignableTo<IMapper>())
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }
    }
}
