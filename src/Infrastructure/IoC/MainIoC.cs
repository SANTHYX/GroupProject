﻿using Autofac;
using Infrastructure.IoC.Modules;

namespace Infrastructure.IoC
{
    public class MainIoC : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule<FactoriesModule>();
            builder.RegisterModule<RepositoriesModule>();
            builder.RegisterModule<CQRSModule>();
            builder.RegisterModule<SecurityModule>();
        }
    }
}