using AppMemoryCache.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppMemoryCache.Core.Interfaces
{
    public interface IProductService
    {
        void Create(Product product);
        Product FindById(int id);
        IEnumerable<Product> GetAll();
    }
}
