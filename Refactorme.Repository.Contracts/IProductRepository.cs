using Refactoreme.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refactorme.Repository.Contracts
{
    public interface IProductRepository
    {
        Task<IList<Product>> GetAllProductsAsync();

        Task<Product> GetProductByIdAsync(Guid id);

        Task<IList<Product>> SearchProductsByNameAsync(string name);

        Task<Product> CreateProductAsync(Product product);

        Task<Product> UpdateProductAsync(Guid id, Product product);

        Task<Product> DeleteProductAsync(Guid id);
    }
}
