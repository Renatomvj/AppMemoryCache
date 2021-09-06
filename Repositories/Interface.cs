using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppMemoryCache.Repositories
{
    public interface IDatabaseBootstrap
    {
        void Setup();
    }
}
