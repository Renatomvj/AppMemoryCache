using AppMemoryCache.Core.Entities;
using AppMemoryCache.Core.Interfaces;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppMemoryCache.Core
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;
        private readonly IMemoryCache _memoryCache;
        private readonly ILogger _logger;
        public ProductService(IProductRepository repository, IMemoryCache memoryCache, ILogger<ProductService> logger)
        {
            this._repository = repository;
            this._memoryCache = memoryCache;
            this._logger = logger;

        }

        public void Create(Product product)
        {
            this._repository.Create(product);
        }

        public Product FindById(int id)
        {

            this._logger.LogInformation("Getting product ...");
            if (!this._memoryCache.TryGetValue(id, out Product product))
            {                
                product = this._repository.FindById(id);

                var cacheEntryOptions = new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromSeconds(10));

                _memoryCache.Set(id, product, cacheEntryOptions);

                this._logger.LogInformation("Product obtained from the database ...");
            }
            this._logger.LogInformation("Returning product ...");

            return product;
        }

        public IEnumerable<Product> GetAll()
        {
            this._logger.LogInformation("Getting products ...");

            string key = $"getallproducts";

            if (!this._memoryCache.TryGetValue(key, out IEnumerable<Product> products))
            {
                products = this._repository.GetAll();

                var cacheEntryOptions = new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromSeconds(10));

                _memoryCache.Set(key, products, cacheEntryOptions);

                this._logger.LogInformation("Products obtained from the database ...");
            }
            this._logger.LogInformation("Returning products ...");

            return products;
        }
    }
}
