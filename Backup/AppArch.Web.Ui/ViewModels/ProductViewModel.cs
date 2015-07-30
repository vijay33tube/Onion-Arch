using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using AppArch.Domain.Entities;

namespace AppArch.Web.Ui.ViewModels
{
    public class ProductViewModel
    {
        public IEnumerable<Category> Categories { get; set; }
        public Category SelectedCategory { get; set; }
        public IEnumerable<Product> Products { get; set; }
    }
}