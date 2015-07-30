using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppArch.Domain.Entities
{
    public class Category
    {
        public virtual int CategoryId { get; set; }
        public virtual string CategoryName { get; set; }
        public virtual IEnumerable<Product> Products { get; set; }
    }
}
