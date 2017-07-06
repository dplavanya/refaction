using Refactorme.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Refactoreme.Data.Models;
using Refactorme.Data;

namespace Refactorme.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public ProductRepository()
        {
            _applicationDbContext = new ApplicationDbContext();
        }

        public async Task<IList<Product>> GetAllProductsAsync()
        {
            return await _applicationDbContext.Products.ToListAsync();
        }

        public async Task<Product> GetProductByIdAsync(Guid id)
        {
            return await _applicationDbContext.Products.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IList<Product>> SearchProductsByNameAsync(string name)
        {
            return await _applicationDbContext.Products.Where(p => p.Name.StartsWith(name)).ToListAsync();
        }

        public async Task<bool> DeleteProductAsync(Guid id)
        {
            var product = await _applicationDbContext.Products.FindAsync(id);

            if (product == null)
            {
                return false;
            }
            _applicationDbContext.Products.Remove(product);

            await _applicationDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<Product> UpdateProductAsync(Guid id, Product product)
        {
            var prod = await _applicationDbContext.Products.FindAsync(id);

            if (prod == null || prod.IsNew)
            {
                return null;
            }

            product.Id = id;
            product.CreatedDate = prod.CreatedDate;
            _applicationDbContext.Products.AddOrUpdate(product);

            await _applicationDbContext.SaveChangesAsync();

            return product;
        }

        public async Task<Product> CreateProductAsync(Product product)
        {
            var createdproduct = _applicationDbContext.Products.Add(product);
            await _applicationDbContext.SaveChangesAsync();
            return createdproduct;
        }

        
    }
}
