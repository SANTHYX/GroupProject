using Autofac;
using Core.Commons.Security;
using Infrastructure.Security;

namespace Infrastructure.IoC.Modules
{
    public class SecurityModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<Encryptor>()
                .As<IEncryptor>()
                .SingleInstance();
        }
    }
}
