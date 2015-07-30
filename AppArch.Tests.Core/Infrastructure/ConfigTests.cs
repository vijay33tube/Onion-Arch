using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Ninject;
using NUnit.Framework;

using AppArch.Tests.Core.Services;
using AppArch.Infrastructure.Interfaces;
using AppArch.Tests.Core.DependencyResolution;

namespace AppArch.Tests.Core.Infrastructure
{
    [TestFixture]
    public class ConfigTests
    {
        // Ninject kernel
        private IKernel _ninjectKernel;

        public ConfigTests()
        {
            // Init Ninject kernel
            _ninjectKernel = new StandardKernel
            (
                new TestConfigModule()
            );
        }

        [Test]
        public void Should_Get_Connection_String_From_Config()
        {
            // Arrange

            var config = _ninjectKernel.Get<IConfigService>();

            // Act

            var connStrVal = @"Data Source=.\sqlexpress;Initial Catalog=Northwind;Integrated Security=True";
            var connStr = config.NorthwindConnection;

            // Assert

            Assert.That(connStr == connStrVal);
        }
    }
}
