﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppArch.Domain.Entities
{
    public class Product
    {
        public virtual int ProductId { get; set; }
        public virtual string ProductName { get; set; }
        public virtual decimal UnitPrice { get; set; }
        public virtual bool Discontinued { get; set; }
        public virtual Category Category { get; set; }
    }
}
