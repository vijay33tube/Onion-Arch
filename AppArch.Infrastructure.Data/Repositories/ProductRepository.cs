using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NHibernate.Linq;

using AppArch.Domain.Interfaces;
using AppArch.Domain.Entities;

namespace AppArch.Infrastructure.Data
{
    public class ProductRepository : RepositoryBase, IProductRepository
    {
        SessionHelper _nhibernate;

        public ProductRepository(string connectionString)
            : base(connectionString)
        {
            _nhibernate = new SessionHelper(_connectionString);
        }

        public IEnumerable<Product> GetProducts()
        {
            using (var session = _nhibernate.OpenSession())
            {
                var products = (from p in session.Query<Product>()
                                  orderby p
                                  select p).ToList();
                return products;
            }
        }

        public IEnumerable<Product> GetProductsByCategoryId(int categoryId)
        {
            using (var session = _nhibernate.OpenSession())
            {
                var products = (from p in session.Query<Product>()
                                where p.Category.CategoryId == categoryId
                                orderby p
                                select p).ToList();
                return products;
            }
        }
    }
}
