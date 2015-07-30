using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

using Moq;
using Ninject;
using NUnit.Framework;
using NUnit.Framework.Constraints;

using AppArch.Infrastructure.DependecyResolution;
using AppArch.Services.Interfaces;
using AppArch.Tests.Core.DependencyResolution;

using AppArch.Web.Ui.Services;
using AppArch.Web.Ui.ViewModels;
using AppArch.Web.Ui.Controllers;
using AppArch.Domain.Interfaces;

namespace AppArch.Tests.Core.Controllers
{
    [TestFixture]
    public class ProductControllerTests
    {
        // Ninject kernel
        private IKernel _ninjectKernel;

        public ProductControllerTests()
        {
            // Init Ninject kernel
            _ninjectKernel = new StandardKernel
                (
                    new LoggingModule(),
                    new TestConfigModule(),
                    new TestRepositoryModule()
                );
            _ninjectKernel.Bind<IProductService>().To<ProductService>();
        }

        [Test]
        public void Product_Controller_Should_Return_View_With_Categories()
        {
            // Arrange

            var controller = _ninjectKernel.Get<ProductController>();

            // Act

            var result = controller.Index() as ViewResult;
            var model = (ProductViewModel)result.Model;

            // Assert
            Assert.That(model, Is.Not.Null);
            Assert.That(model.Products, Is.Empty);
            Assert.That(model.SelectedCategory, Is.Null);
            Assert.That(model.Categories, Has.Count.EqualTo(3));
        }

        [Test]
        public void Product_Controller_Should_Return_View_With_Beverages()
        {
            // Arrange

            var categoryId = 1;
            var categoriesRep = _ninjectKernel.Get<ICategoryRepository>();
            var productsRep = _ninjectKernel.Get<IProductRepository>();
            var beverages = productsRep.GetProducts().Where(p => p.Category.CategoryId == categoryId);
            var mockProductsRep = Mock.Get<IProductRepository>(productsRep);
            mockProductsRep.Setup(m => m.GetProductsByCategoryId(categoryId)).Returns(beverages.ToList());
            
            var controller = _ninjectKernel.Get<ProductController>();

            // Act

            var bevCategory = categoriesRep.GetCategories()
                .Where(c => c.CategoryId == categoryId)
                .SingleOrDefault();
            var result = controller.Index(categoryId) as ViewResult;
            var model = (ProductViewModel)result.Model;

            // Assert
            Assert.That(model, Is.Not.Null);
            Assert.That(model.SelectedCategory, Is.SameAs(bevCategory));
            Assert.That(model.Products, Has.Count.EqualTo(2));
        }
    }
}
