using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Moq;
using Ninject;
using NUnit.Framework;

using AppArch.Tests.Core.Services;
using AppArch.Domain.Entities;
using AppArch.Domain.Interfaces;
using AppArch.Infrastructure.Interfaces;
using AppArch.Infrastructure.DependecyResolution;
using AppArch.Tests.Core.DependencyResolution;

namespace AppArch.Tests.Repositories.Integration
{
    [TestFixture]
    public class RepositoryTests
    {
        // Ninject kernel
        private IKernel _ninjectKernel;

        public RepositoryTests()
        {
            // Init Ninject kernel
            _ninjectKernel = new StandardKernel
                (
                    new TestConfigModule(),
                    new RepositoryModule(), 
                    new LoggingModule()
                );
        }

        [Test]
        public void Should_Get_All_Categories()
        {
            // Arrange
            
            var categoriesRep = _ninjectKernel.Get<ICategoryRepository>();

            // Act

            var categories = categoriesRep.GetCategories();

            // Assert

            Assert.That(categories != null);
            Assert.That(categories.Count() > 0);
        }

        [Test]
        public void Should_Get_All_Products()
        {
            // Arrange

            var productsRep = _ninjectKernel.Get<IProductRepository>();

            // Act

            var products = productsRep.GetProducts();

            // Assert

            Assert.That(products != null);
            Assert.That(products.Count() > 0);
        }

        [Test]
        public void Should_Get_Products_For_Beverages_Category()
        {
            // Arrange

            var productsRep = _ninjectKernel.Get<IProductRepository>();

            // Act

            var categoryId = 1;
            var products = productsRep.GetProductsByCategoryId(categoryId);

            // Assert

            Assert.That(products != null);
            Assert.That(products.Count() > 0);
        }
    }
}
