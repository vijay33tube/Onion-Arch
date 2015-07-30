using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using AppArch.Domain.Entities;
using AppArch.Web.Ui.ViewModels;
using AppArch.Services.Interfaces;
using AppArch.Infrastructure.Interfaces;

namespace AppArch.Web.Ui.Controllers
{
    public class ProductController : Controller
    {
        // Services will be injected
        private IProductService _productService;
        private ILoggingService _loggingService;

        public ProductController(IProductService productService,
            ILoggingService loggingService)
        {
            _productService = productService;
            _loggingService = loggingService;
        }

        //
        // GET: /Product/

        public ActionResult Index()
        {
            // Get view model
            ProductViewModel viewModel = GetProductViewModel(null);

            // Log action
            _loggingService.Trace("GET Action: ProductController.Index");

            // Return view
            return View(viewModel);
        }

        //
        // POST: /Product/

        [HttpPost]
        public ActionResult Index(int categoryId)
        {
            // Get view model
            ProductViewModel viewModel = GetProductViewModel(categoryId);

            // Log action
            _loggingService.Trace("POST Action: ProductController.Index");

            // Return view
            return View(viewModel);
        }

        public ProductViewModel GetProductViewModel(int? selectedCategoryId)
        {
            // Get categories
            var categories = _productService.GetCategories();

            // Get products
            var products = _productService.GetProducts(selectedCategoryId);

            // Set selected category
            Category selectedCategory = null;
            int categoryId = selectedCategoryId.GetValueOrDefault();
            if (categories.Count() > 0)
            {
                if (categoryId > 0)
                {
                    selectedCategory = (from c in categories
                                        where c.CategoryId == categoryId
                                        select c).FirstOrDefault();
                }
            }

            // Return product view model
            ProductViewModel productViewModel = new ProductViewModel
            {
                Categories = categories,
                SelectedCategory = selectedCategory,
                Products = products
            };
            return productViewModel;
        }
    }
}
