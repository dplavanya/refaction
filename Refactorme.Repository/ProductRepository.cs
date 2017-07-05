using Refactorme.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Refactoreme.Data.Models;

namespace Refactorme.Repository
{
    public class ProductRepository : IProductRepository
    {
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

        public Task<bool> DeleteProductAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Product> UpdateProductAsync(Guid id, Product product)
        {
            throw new NotImplementedException();
        }

        public Task<Product> CreateProductAsync(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
