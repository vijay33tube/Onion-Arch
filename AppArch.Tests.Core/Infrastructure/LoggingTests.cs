using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Moq;
using Ninject;
using NUnit.Framework;

using AppArch.Services.Interfaces;
using AppArch.Infrastructure.Interfaces;
using AppArch.Infrastructure.DependecyResolution;

namespace AppArch.Tests
{
    [TestFixture]
    public class LoggingTests
    {
        // Ninject kernel
        private IKernel _ninjectKernel;

        public LoggingTests()
        {
            // Init Ninject kernel
            _ninjectKernel = new StandardKernel(new LoggingModule());
        }

        [Test]
        public void Should_Log_Message()
        {
            // Arrange

            var logger = _ninjectKernel.Get<ILoggingService>();

            // Act

            try
            {
                throw new Exception("Tried to divide by zero", new DivideByZeroException());
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }

            // Assert

            Assert.Pass("Check Debug output for log message");
        }
    }
}
