using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using refactor_me.Models;

namespace refactor_me.Services
{
    public class ProductService : IProductService
    {
        public Task<Product> CreateProductAsync(Product product)
        {
            throw new NotImplementedException();
        }

        public Task<Product> DeleteProductAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IList<Product>> GetAllProductsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Product> GetProductByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IList<Product>> SearchProductsByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public Task<Product> UpdateProductAsync(Guid id, Product product)
        {
            throw new NotImplementedException();
        }
    }
}