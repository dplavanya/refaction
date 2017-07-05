using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using refactor_me.Models;
using Refactorme.Repository.Contracts;

namespace refactor_me.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<Refactoreme.Data.Models.Product> CreateProductAsync(Refactoreme.Data.Models.Product product)
        {
            return await _productRepository.CreateProductAsync(product);
        }

        public async Task<bool> DeleteProductAsync(Guid id)
        {
            return await _productRepository.DeleteProductAsync(id);
        }

        public async Task<IList<Refactoreme.Data.Models.Product>> GetAllProductsAsync()
        {
            return await _productRepository.GetAllProductsAsync();
        }

        public async Task<Refactoreme.Data.Models.Product> GetProductByIdAsync(Guid id)
        {
            return await _productRepository.GetProductByIdAsync(id);
        }

        public async Task<IList<Refactoreme.Data.Models.Product>> SearchProductsByNameAsync(string name)
        {
            return await _productRepository.SearchProductsByNameAsync(name);
        }

        public async Task<Refactoreme.Data.Models.Product> UpdateProductAsync(Guid id, Refactoreme.Data.Models.Product product)
        {
            return await _productRepository.UpdateProductAsync(id, product);
        }
    }
}