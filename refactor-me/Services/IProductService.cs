using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using refactor_me.Models;

namespace refactor_me.Services
{
    public interface IProductService
    {
        Task<IList<Product>> GetAllProductsAsync();

        Task<Product> GetProductByIdAsync(Guid id);

        Task<IList<Product>> SearchProductsByNameAsync(string name);

        Task<Product> CreateProductAsync(Product product);

        Task<Product> UpdateProductAsync(Guid id, Product product);

        Task<Product> DeleteProductAsync(Guid id);


    }
}