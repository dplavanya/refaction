using Refactoreme.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refactorme.Repository.Contracts
{
    public interface IProductOptionRepository
    {
        Task<IList<ProductOption>> GetAllProductOptionsByProductIdAsync(Guid productId);

        Task<ProductOption> GetProductOptionByOptionIdAsync(Guid productId, Guid optionId);

        Task<ProductOption> CreateProductOptionAsync(ProductOption productOption);

        Task<ProductOption> UpdateProductOptionAsync(ProductOption productOption);

        Task<bool> DeleteProductOptionAsync(Guid productId, Guid optionId);
    }
}
