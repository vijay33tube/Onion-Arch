using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppArch.Infrastructure.Data
{
    public class RepositoryBase
    {
        protected string _connectionString;

        public RepositoryBase(string connectionString)
        {
            _connectionString = connectionString;
        }
    }
}
