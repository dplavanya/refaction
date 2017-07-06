using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Refactoreme.Data.Models;

namespace refactor_me.Services
{
    public class ProductOptionService : IProductOptionService
    {
        public Task<IList<ProductOption>> GetAllProductOptionsByProductIdAsync(Guid productId)
        {
            throw new NotImplementedException();
        }

        public Task<ProductOption> GetProductOptionByOptionIdAsync(Guid productId, Guid optionId)
        {
            throw new NotImplementedException();
        }

        public Task<ProductOption> UpdateProductOptionAsync(ProductOption productOption)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteProductOptionAsync(Guid productId, Guid optionId)
        {
            throw new NotImplementedException();
        }
    }
}