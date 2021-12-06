using Application.Commons.Tools;
using Autofac;
using Infrastructure.Tools;

namespace Infrastructure.IoC.Modules
{
    public class ToolsModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<VideoWriter>()
                .As<IVideoWriter>()
                .InstancePerLifetimeScope();
        }
    }
}
