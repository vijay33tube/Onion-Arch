using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Moq;
using Ninject.Modules;

using AppArch.Infrastructure.Interfaces;
using AppArch.Tests.Core.Services;
using AppArch.Domain.Entities;
using AppArch.Domain.Interfaces;

namespace AppArch.Tests.Core.DependencyResolution
{
    public class TestRepositoryModule : NinjectModule
    {
        public override void Load()
        {
            // Init categories
            var categories = new List<Category>
            {
                new Category { CategoryId = 1, CategoryName = "Beverages" },
                new Category { CategoryId = 2, CategoryName = "Condiments" },
                new Category { CategoryId = 3, CategoryName = "Confections" }
            };

            // Init products
            var products = new List<Product>
            {
                new Product { ProductId = 1, ProductName = "Chai", UnitPrice = 18M,
                    Category = categories[0] },
                new Product { ProductId = 1, ProductName = "Chang", UnitPrice = 19M,
                    Category = categories[0] },
                new Product { ProductId = 1, ProductName = "Aniseed Syrup", UnitPrice = 10M,
                    Category = categories[1] }
            };

            // Set up mock categories repository
            var mockCategoriesRep = new Mock<ICategoryRepository>();
            mockCategoriesRep.Setup(m => m.GetCategories()).Returns(categories);
            Kernel.Bind<ICategoryRepository>().ToConstant(mockCategoriesRep.Object);

            // Set up mock products repository
            var mockProductsRep = new Mock<IProductRepository>();
            mockProductsRep.Setup(m => m.GetProducts()).Returns(products);
            Kernel.Bind<IProductRepository>().ToConstant(mockProductsRep.Object);
        }
    }
}
