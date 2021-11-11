using Application.Commons.CQRS.Command;
using Application.Commons.CQRS.Query;
using Autofac;
using Infrastructure.CQRS;
using System.Reflection;

namespace Infrastructure.IoC.Modules
{
    public class CQRSModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var asembly = typeof(CQRSModule).GetTypeInfo().Assembly;
            
            builder.RegisterAssemblyTypes(asembly)
                .AsClosedTypesOf(typeof(ICommandHandler<>))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(asembly)
                .AsClosedTypesOf(typeof(IQueryHandler<,>))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder.RegisterType<CommandDispatcher>()
                .As<ICommandDispatcher>()
                .InstancePerLifetimeScope();

            builder.RegisterType<QueryDispatcher>()
                .As<IQueryDispatcher>()
                .InstancePerLifetimeScope();
        }
    }
}
