using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Refactoreme.Data.Models;

namespace refactor_me.Services
{
    public interface IProductOptionService
    {
        Task<IList<ProductOption>> GetAllProductOptionsByProductIdAsync(Guid productId);

        Task<ProductOption> GetProductOptionByOptionIdAsync(Guid productId, Guid optionId);

        Task<ProductOption> UpdateProductOptionAsync(ProductOption productOption);

        Task<bool> DeleteProductOptionAsync(Guid productId, Guid optionId);
    }
}