using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Moq;
using Ninject;
using NUnit.Framework;

using AppArch.Domain.Entities;
using AppArch.Domain.Interfaces;
using AppArch.Tests.Core.DependencyResolution;

namespace AppArch.Tests.Unit
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
                    new TestRepositoryModule()
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
            Assert.That(categories.Count() == 3);
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
            Assert.That(products.Count() == 3);
        }

        [Test]
        public void Should_Get_Products_For_Beverages_Category()
        {
            // Arrange

            var categoryId = 1;
            var productsRep = _ninjectKernel.Get<IProductRepository>();
            var beverages = productsRep.GetProducts().Where(p => p.Category.CategoryId == categoryId);
            var mockProductsRep = Mock.Get<IProductRepository>(productsRep);
            mockProductsRep.Setup(m => m.GetProductsByCategoryId(categoryId)).Returns(beverages.ToList());

            // Act

            var products = productsRep.GetProductsByCategoryId(categoryId);

            // Assert

            Assert.That(products != null);
            Assert.That(products.Count() == 2);
        }
    }
}
