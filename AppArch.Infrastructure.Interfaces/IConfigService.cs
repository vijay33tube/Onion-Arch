using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppArch.Infrastructure.Interfaces
{
    public interface IConfigService
    {
        string NorthwindConnection { get; }
    }
}
