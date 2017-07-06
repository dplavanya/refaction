using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Refactoreme.Data.Models;
using Refactorme.Data;
using Refactorme.Repository.Contracts;
using System.Data.Entity;
using System.Data.Entity.Migrations;

namespace Refactorme.Repository
{
    public class ProductOptionRepository : IProductOptionRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public ProductOptionRepository()
        {
            _applicationDbContext = new ApplicationDbContext();
        }
        public async Task<bool> DeleteProductOptionAsync(Guid productId, Guid optionId)
        {
            var productOption = await _applicationDbContext.ProductOptions.FindAsync(optionId);

            if (productOption == null || productOption.ProductId != productId)
            {
                return false;
            }
            _applicationDbContext.ProductOptions.Remove(productOption);
            await _applicationDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<IList<ProductOption>> GetAllProductOptionsByProductIdAsync(Guid productId)
        {
            return await _applicationDbContext.ProductOptions.Where(p => p.ProductId == productId).ToListAsync();
        }

        public async Task<ProductOption> GetProductOptionByOptionIdAsync(Guid productId, Guid optionId)
        {
            return await _applicationDbContext.ProductOptions.SingleOrDefaultAsync(
                p => p.ProductId == productId && p.Id == optionId && p.IsNew == false);
        }

        public async Task<ProductOption> UpdateProductOptionAsync(ProductOption productOption)
        {
            var prodOption = await _applicationDbContext.ProductOptions.FindAsync(productOption.Id);

            if (prodOption == null || prodOption.IsNew)
            {
                return null;
            }

            productOption.CreatedDate = prodOption.CreatedDate;

            _applicationDbContext.ProductOptions.AddOrUpdate(productOption);
            await _applicationDbContext.SaveChangesAsync();
            return productOption;
        }

        public async Task<ProductOption> CreateProductOptionAsync(ProductOption productOption)
        {

            var prodOption = _applicationDbContext.ProductOptions.Add(productOption);
            await _applicationDbContext.SaveChangesAsync();
            return prodOption;
        }
    }
}
