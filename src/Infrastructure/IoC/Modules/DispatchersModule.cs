using Application.Commons.CQRS.Command;
using Application.Commons.CQRS.Query;
using Application.Identity.Commands.RegisterUser;
using Autofac;
using Infrastructure.CQRS;
using System.Reflection;

namespace Infrastructure.IoC.Modules
{
    public class DispatchersModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var asembly = typeof(DispatchersModule).GetTypeInfo().Assembly;

            builder.RegisterType<CommandDispatcher>()
                .As<ICommandDispatcher>()
                .InstancePerLifetimeScope();

            builder.RegisterType<QueryDispatcher>()
                .As<IQueryDispatcher>()
                .InstancePerLifetimeScope();
        }
    }
}
