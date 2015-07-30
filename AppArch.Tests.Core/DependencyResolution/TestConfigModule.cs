using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Ninject.Modules;

using AppArch.Infrastructure.Interfaces;
using AppArch.Tests.Core.Services;

namespace AppArch.Tests.Core.DependencyResolution
{
    public class TestConfigModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IConfigService>().To<TestConfigService>();
        }
    }
}
