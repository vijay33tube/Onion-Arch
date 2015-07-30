using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NHibernate.Linq;

using AppArch.Domain.Interfaces;
using AppArch.Domain.Entities;
using AppArch.Infrastructure.Interfaces;

namespace AppArch.Infrastructure.Data
{
    public class CategoryRepository : RepositoryBase, ICategoryRepository
    {
        private SessionHelper _nhibernate;
        private ILoggingService _loggingService;

        public CategoryRepository(string connectionString, ILoggingService loggingService)
            : base(connectionString)
        {
            _nhibernate = new SessionHelper(_connectionString);
            _loggingService = loggingService;
        }

        public IEnumerable<Category> GetCategories()
        {
            using (var session = _nhibernate.OpenSession())
            {
                var categories = (from c in session.Query<Category>()
                                  orderby c.CategoryName
                                  select c).ToList();

                // Log call
                _loggingService.Trace("AppArch.Infrastructure.Data: CategoryRepository.GetCategories");
                
                return categories;
            }
        }
    }
}
