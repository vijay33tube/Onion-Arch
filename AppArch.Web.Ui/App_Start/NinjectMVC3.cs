using AppArch.Infrastructure.DependecyResolution;

[assembly: WebActivator.PreApplicationStartMethod(typeof(AppArch.Web.Ui.App_Start.NinjectMVC3), "Start")]
[assembly: WebActivator.ApplicationShutdownMethodAttribute(typeof(AppArch.Web.Ui.App_Start.NinjectMVC3), "Stop")]

namespace AppArch.Web.Ui.App_Start
{
    using System.Reflection;
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;
    using Ninject;
    using Ninject.Web.Mvc;
    using Ninject.Modules;

    using AppArch.Services.Interfaces;
    using AppArch.Web.Ui.Services;
    using System.Collections.Generic;


    public static class NinjectMVC3 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestModule));
            DynamicModuleUtility.RegisterModule(typeof(HttpApplicationInitializationModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            RegisterServices(kernel);
            return kernel;
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            // Bind local services
            kernel.Bind<IProductService>().To<ProductService>();

            // Add data and infrastructure modules
            var modules = new List<INinjectModule>
                {
                    new ConfigModule(),
                    new RepositoryModule(),
                    new LoggingModule()
                };
            kernel.Load(modules);
        }
    }
}
