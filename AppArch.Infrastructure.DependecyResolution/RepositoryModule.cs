using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Ninject;
using Ninject.Modules;

using AppArch.Domain.Interfaces;
using AppArch.Infrastructure.Data;
using AppArch.Infrastructure.Interfaces;

namespace AppArch.Infrastructure.DependecyResolution
{
    public class RepositoryModule : NinjectModule
    {
        public override void Load()
        {
            // Get config service
            var configService = Kernel.Get<IConfigService>();
            
            // Bind repositories
            Bind<ICategoryRepository>().To<CategoryRepository>()
                .WithConstructorArgument("connectionString", configService.NorthwindConnection);
            Bind<IProductRepository>().To<ProductRepository>()
                .WithConstructorArgument("connectionString", configService.NorthwindConnection);
        }
    }
}
