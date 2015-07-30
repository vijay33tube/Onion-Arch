using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using AppArch.Domain.Entities;
using AppArch.Domain.Interfaces;
using AppArch.Services.Interfaces;

namespace AppArch.Web.Ui.Services
{
    public class ProductService : IProductService
    {
        // Repositories will be injected
        ICategoryRepository _categoriesRep;
        IProductRepository _productsRep;

        public ProductService(ICategoryRepository categoriesRep,
            IProductRepository productsRep)
        {
            _categoriesRep = categoriesRep;
            _productsRep = productsRep;
        }

        public IEnumerable<Category> GetCategories()
        {
            // Return all categories
            IEnumerable<Category> categories = _categoriesRep.GetCategories();
            return categories;
        }

        public IEnumerable<Product> GetProducts(int? categoryId)
        {
            // Return products by category or none if no category specified
            IEnumerable<Product> products = Enumerable.Empty<Product>();
            if (categoryId != null)
            {
                products = _productsRep.GetProductsByCategoryId((int)categoryId);
            }
            return products;
        }        
   }
}