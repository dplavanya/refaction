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

namespace refactor_me.Controllers
{
    [RoutePrefix("products")]
    public class ProductController : ApiController
    {
        private readonly IProductService _productService;
        private readonly IProductOptionService _productOptionService;

        public ProductController(IProductService productService, IProductOptionService productOptionService)
        {
            _productService = productService;
            _productOptionService = productOptionService;
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
        public async Task<IHttpActionResult> GetProductOptions(Guid productId)
        {
            var productOptions = await _productOptionService.GetAllProductOptionsByProductIdAsync(productId);
            if (productOptions.Any())
            {
                return Ok(productOptions);
            }
            return NotFound();
        }

        [Route("{productId}/options/{id}")]
        [HttpGet]
        public async Task<IHttpActionResult> GetProductOption(Guid productId, Guid id)
        {
            var productOption = await _productOptionService.GetProductOptionByOptionIdAsync(productId, id);
            if (productOption != null)
            {
                return Ok(productOption);
            }
            return NotFound();
        }

        [Route("{productId}/options")]
        [HttpPost]
        public async Task<IHttpActionResult> CreateOption(Guid productId, ProductOption option)
        {
            option.ProductId = productId;

            var newProductOption = await _productOptionService.CreateProductOptionAsync(option);
            if (newProductOption != null)
            {
                return Ok(newProductOption);
            }
            return InternalServerError();
        }

        [Route("{productId}/options/{id}")]
        [HttpPut]
        public async Task<IHttpActionResult> UpdateOption(Guid productId, ProductOption option, Guid id)
        {
            option.ProductId = productId;
            option.Id = id;


            var updatedOption = await _productOptionService.UpdateProductOptionAsync(option);

            if (updatedOption != null)
            {
                return Ok(updatedOption);
            }

            return InternalServerError();
        }

        [Route("{productId}/options/{id}")]
        [HttpDelete]
        public async Task<IHttpActionResult> DeleteOption(Guid productId, Guid id)
        {
            var result = await _productOptionService.DeleteProductOptionAsync(productId, id);
            if (result)
            {
                return Ok();
            }
            return InternalServerError();
        }
    }
}
