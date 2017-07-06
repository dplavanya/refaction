using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace refactor_me.Services
{
    public interface IProductService
    {
        Task<IList<Refactoreme.Data.Models.Product>> GetAllProductsAsync();

        Task<Refactoreme.Data.Models.Product> GetProductByIdAsync(Guid id);

        Task<IList<Refactoreme.Data.Models.Product>> SearchProductsByNameAsync(string name);

        Task<Refactoreme.Data.Models.Product> CreateProductAsync(Refactoreme.Data.Models.Product product);

        Task<Refactoreme.Data.Models.Product> UpdateProductAsync(Guid id, Refactoreme.Data.Models.Product product);

        Task<bool> DeleteProductAsync(Guid id);


    }
}