using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using FluentNHibernate.Mapping;
using AppArch.Domain.Entities;

namespace AppArch.Infrastructure.Data
{
    public class ProductMap : ClassMap<Product>
    {
        public ProductMap()
        {
            Id(x => x.ProductId);
            Map(x => x.ProductName);
            Map(x => x.UnitPrice);
            Map(x => x.Discontinued);
            References(x => x.Category, "CategoryId");
            Table("Products");
        }
    }
}
