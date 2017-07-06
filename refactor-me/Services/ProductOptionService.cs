using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Refactoreme.Data.Models;
using Refactorme.Repository.Contracts;

namespace refactor_me.Services
{
    public class ProductOptionService : IProductOptionService
    {
        private readonly IProductOptionRepository _productOptionRepository;


        public ProductOptionService(IProductOptionRepository productOptionRepository)
        {
            _productOptionRepository = productOptionRepository;
        }

        public async Task<IList<ProductOption>> GetAllProductOptionsByProductIdAsync(Guid productId)
        {
            return await _productOptionRepository.GetAllProductOptionsByProductIdAsync(productId);
        }

        public async Task<ProductOption> GetProductOptionByOptionIdAsync(Guid productId, Guid optionId)
        {
            return await _productOptionRepository.GetProductOptionByOptionIdAsync(productId, optionId);

        }

        public async Task<ProductOption> UpdateProductOptionAsync(ProductOption productOption)
        {
            return await _productOptionRepository.UpdateProductOptionAsync(productOption);
        }

        public async Task<bool> DeleteProductOptionAsync(Guid productId, Guid optionId)
        {
            return await _productOptionRepository.DeleteProductOptionAsync(productId, optionId);
        }

        public async Task<ProductOption> CreateProductOptionAsync(ProductOption productOption)
        {
            return await _productOptionRepository.CreateProductOptionAsync(productOption);
        }

    }

}
