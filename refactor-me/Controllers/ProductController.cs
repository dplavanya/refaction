using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using refactor_me.Models;
using refactor_me.Services;
using Refactoreme.Data.Models;
using ProductOption = refactor_me.Models.ProductOption;

namespace refactor_me.Controllers
{
    [RoutePrefix("products")]
    public class ProductController : ApiController
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [Route]
        [HttpGet]
        public async Task<IHttpActionResult> GetAll()
        {
            var products = await _productService.GetAllProductsAsync();

            if (products.Any())
            {
                return Ok(products);
            }
            return NotFound();
        }

        [Route]
        [HttpGet]
        public async Task<IHttpActionResult> SearchByName(string name)
        {
            var products = await _productService.SearchProductsByNameAsync(name);
            if (products.Any())
            {
                return Ok(products);
            }
            return NotFound();

        }

        [Route("{id}")]
        [HttpGet]
        public async Task<IHttpActionResult> GetProduct(Guid id)
        {

            var product = await _productService.GetProductByIdAsync(id);
            if (product != null)
            {
                return Ok(product);
            }
            return NotFound();
        }

        [Route]
        [HttpPost]
        public async Task<IHttpActionResult> Create(Product product)
        {
            var newProduct = await _productService.CreateProductAsync(product);

            if (product != null)
            {
                return Ok(newProduct);
            }

            return InternalServerError();
        }

        [Route("{id}")]
        [HttpPut]
        public async Task<IHttpActionResult> Update(Guid id, Product product)
        {
            var updatedProduct = await _productService.UpdateProductAsync(id, product);
            if (updatedProduct != null)
            {
                return Ok(updatedProduct);
            }
            return InternalServerError();
        }

        [Route("{id}")]
        [HttpDelete]
        public async Task<IHttpActionResult> Delete(Guid id)
        {
            var result = await _productService.DeleteProductAsync(id);
            if (result)
            {
                return Ok();
            }
            return InternalServerError();
        }

        [Route("{productId}/options")]
        [HttpGet]
        public ProductOptions GetOptions(Guid productId)
        {
            return new ProductOptions(productId);
        }

        [Route("{productId}/options/{id}")]
        [HttpGet]
        public ProductOption GetOption(Guid productId, Guid id)
        {
            var option = new ProductOption(id);
            if (option.IsNew)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return option;
        }

        [Route("{productId}/options")]
        [HttpPost]
        public void CreateOption(Guid productId, ProductOption option)
        {
            option.ProductId = productId;
            option.Save();
        }

        [Route("{productId}/options/{id}")]
        [HttpPut]
        public void UpdateOption(Guid id, ProductOption option)
        {
            var orig = new ProductOption(id)
            {
                Name = option.Name,
                Description = option.Description
            };

            if (!orig.IsNew)
                orig.Save();
        }

        [Route("{productId}/options/{id}")]
        [HttpDelete]
        public void DeleteOption(Guid id)
        {
            var opt = new ProductOption(id);
            opt.Delete();
        }
    }
}
