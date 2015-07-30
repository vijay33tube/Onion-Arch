using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ninject.Modules;
using NLog;
using NLog.Config;

using AppArch.Infrastructure.Logging;
using AppArch.Infrastructure.Interfaces;

namespace AppArch.Infrastructure.DependecyResolution
{
    public class LoggingModule : NinjectModule
    {
        public override void Load()
        {
            ILoggingService logger = GetLoggingService();
            Bind<ILoggingService>().ToConstant(logger);
        }

        private ILoggingService GetLoggingService()
        {
            ConfigurationItemFactory.Default.LayoutRenderers
                .RegisterDefinition("utc_date", typeof(UtcDateRenderer));
            ConfigurationItemFactory.Default.LayoutRenderers
                .RegisterDefinition("web_variables", typeof(WebVariablesRenderer));
            ILoggingService logger = (ILoggingService)LogManager.GetLogger("NLogLogger", typeof(LoggingService));
            return logger;
        }
    }
}
