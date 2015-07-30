using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using AppArch.Domain.Entities;

namespace AppArch.Services.Interfaces
{
    public interface IProductService
    {
        IEnumerable<Category> GetCategories();
        IEnumerable<Product> GetProducts(int? categoryId);
    }
}
