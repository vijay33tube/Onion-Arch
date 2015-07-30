using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Ninject.Modules;

using AppArch.Infrastructure.Interfaces;
using AppArch.Infrastructure.Data.Services;

namespace AppArch.Infrastructure.DependecyResolution
{
    public class ConfigModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IConfigService>().To<ConfigService>();
        }
    }
}
