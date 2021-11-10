using Application.Commons.CQRS.Command;
using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.IoC.Modules
{
    public class CQRSModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var asembly = typeof(CQRSModule).GetTypeInfo().Assembly;
            //first use of autofac be proud young padavane
            builder.RegisterAssemblyTypes(asembly).AsClosedTypesOf(typeof(ICommandDispatcher)).InstancePerLifetimeScope();

        }
    }
}
