using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace AppMemoryCache.Core.Interfaces
{
    public interface IConnectionFactory
    {
        IDbConnection Connection();
    }
}
