using Application.Commons.Persistance;
using Autofac;
using Core.Commons.Identity;
using Core.Commons.Repositories;
using Core.Types;
using Infrastructure.Persistance;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reflection;

namespace Infrastructure.IoC.Modules
{
    public class PersistanceModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var assembly = typeof(PersistanceModule).GetTypeInfo().Assembly;

            builder.RegisterAssemblyTypes(assembly)
                .Where(x => x.IsAssignableTo<IRepository>())
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(assembly)
                 .Where(x => x.IsAssignableTo<IInMemoryDatabases>())
                 .AsImplementedInterfaces()
                 .SingleInstance();

            builder.RegisterType<Collection<RecoveryThread>>()
                .As<ICollection<RecoveryThread>>()
                .SingleInstance();
          
            builder.RegisterType<UnitOfWork>()
                .As<IUnitOfWork>()
                .InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(assembly)
                .Where(x => x.IsAssignableTo(typeof(IPage<>)))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();            
        }
    }
}
