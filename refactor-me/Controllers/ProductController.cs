using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using refactor_me.Services;
using Refactoreme.Data.Models;
using Refactorme.Logging;

namespace refactor_me.Controllers
{
    [RoutePrefix("products")]
    public class ProductController : ApiController
    {
        private readonly IProductService _productService;
        private readonly IProductOptionService _productOptionService;
        private readonly ILogger _logger;

        public ProductController(IProductService productService, IProductOptionService productOptionService, ILogger logger)
        {
            _productService = productService;
            _productOptionService = productOptionService;
            _logger = logger;
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

        [Authorize]
        [Route]
        [HttpPost]
        public async Task<IHttpActionResult> Create(Product product)
        {
            try
            {

                var newProduct = await _productService.CreateProductAsync(product);

                if (product != null)
                {
                    return Ok(newProduct);
                }

                var logmessage =
                    $"Create Product Failed in WebApi: {Environment.NewLine}Method: {Request.Method}{Environment.NewLine}URI: {Request.RequestUri}";
                _logger.Error(logmessage, (int)ApplicationEvent.CreateProductFailedEvent, null);
            }

            catch (Exception e)
            {
                var message =
                    $"Unhandled Exception occured in the Web API:{Environment.NewLine}Method: {Request.Method}{Environment.NewLine}URI: {Request.RequestUri} Exception: {e.GetType()}{Environment.NewLine}ExceptionMessage: {e.Message}{Environment.NewLine}Stack Trace: {e.StackTrace}";

                _logger.Error(message, (int)ApplicationEvent.UnhandledApplicationException, e);
            }

            return InternalServerError();
        }

        [Authorize]
        [Route("{id}")]
        [HttpPut]
        public async Task<IHttpActionResult> Update(Guid id, Product product)
        {
            try
            {

                var updatedProduct = await _productService.UpdateProductAsync(id, product);
                if (updatedProduct != null)
                {
                    return Ok(updatedProduct);
                }

                var logmessage =
                    $"Update Product Failed in WebApi: {Environment.NewLine}Method: {Request.Method}{Environment.NewLine}URI: {Request.RequestUri}";
                _logger.Error(logmessage, (int)ApplicationEvent.UpdateProductFailedEvent, null);
            }

            catch (Exception e)
            {
                var message =
                    $"Unhandled Exception occured in the Web API:{Environment.NewLine}Method: {Request.Method}{Environment.NewLine}URI: {Request.RequestUri} Exception: {e.GetType()}{Environment.NewLine}ExceptionMessage: {e.Message}{Environment.NewLine}Stack Trace: {e.StackTrace}";

                _logger.Error(message, (int)ApplicationEvent.UnhandledApplicationException, e);
            }
            return InternalServerError();
        }

        [Authorize]
        [Route("{id}")]
        [HttpDelete]
        public async Task<IHttpActionResult> Delete(Guid id)
        {
            try
            {
                var result = await _productService.DeleteProductAsync(id);
                if (result)
                {
                    return Ok();
                }

                var logmessage =
                    $"Delete Product Failed in WebApi: {Environment.NewLine}Method: {Request.Method}{Environment.NewLine}URI: {Request.RequestUri}";
                _logger.Error(logmessage, (int)ApplicationEvent.DeleteProductFailedEvent, null);
            }

            catch (Exception e)
            {
                var message =
                    $"Unhandled Exception occured in the Web API:{Environment.NewLine}Method: {Request.Method}{Environment.NewLine}URI: {Request.RequestUri} Exception: {e.GetType()}{Environment.NewLine}ExceptionMessage: {e.Message}{Environment.NewLine}Stack Trace: {e.StackTrace}";

                _logger.Error(message, (int)ApplicationEvent.UnhandledApplicationException, e);
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

        [Authorize]
        [Route("{productId}/options")]
        [HttpPost]
        public async Task<IHttpActionResult> CreateOption(Guid productId, ProductOption option)
        {
            try
            {
                option.ProductId = productId;

                var newProductOption = await _productOptionService.CreateProductOptionAsync(option);
                if (newProductOption != null)
                {
                    return Ok(newProductOption);
                }

                var logmessage =
                    $"Create Option Failed in WebApi: {Environment.NewLine}Method: {Request.Method}{Environment.NewLine}URI: {Request.RequestUri}";
                _logger.Error(logmessage, (int)ApplicationEvent.CreateOptionFailedEvent, null);

            }
            catch (Exception e)
            {
                var message =
                    $"Unhandled Exception occured in the Web API:{Environment.NewLine}Method: {Request.Method}{Environment.NewLine}URI: {Request.RequestUri} Exception: {e.GetType()}{Environment.NewLine}ExceptionMessage: {e.Message}{Environment.NewLine}Stack Trace: {e.StackTrace}";

                _logger.Error(message, (int)ApplicationEvent.UnhandledApplicationException, e);
            }
            return InternalServerError();
        }

        [Authorize]
        [Route("{productId}/options/{id}")]
        [HttpPut]
        public async Task<IHttpActionResult> UpdateOption(Guid productId, ProductOption option, Guid id)
        {
            try
            {
                option.ProductId = productId;
                option.Id = id;


                var updatedOption = await _productOptionService.UpdateProductOptionAsync(option);


                if (updatedOption != null)
                {
                    return Ok(updatedOption);
                }
                var logmessage =
                    $"Update Option Failed in WebApi: {Environment.NewLine}Method: {Request.Method}{Environment.NewLine}URI: {Request.RequestUri}";
                _logger.Error(logmessage, (int)ApplicationEvent.UpdateOptionFailedEvent, null);

            }

            catch (Exception e)
            {
                var message =
                    $"Unhandled Exception occured in the Web API:{Environment.NewLine}Method: {Request.Method}{Environment.NewLine}URI: {Request.RequestUri} Exception: {e.GetType()}{Environment.NewLine}ExceptionMessage: {e.Message}{Environment.NewLine}Stack Trace: {e.StackTrace}";

                _logger.Error(message, (int)ApplicationEvent.UnhandledApplicationException, e);
            }

            return InternalServerError();
        }

        [Authorize]
        [Route("{productId}/options/{id}")]
        [HttpDelete]
        public async Task<IHttpActionResult> DeleteOption(Guid productId, Guid id)
        {
            try
            {
                var result = await _productOptionService.DeleteProductOptionAsync(productId, id);
                if (result)
                {
                    return Ok();
                }
                var logmessage =
                    $"Delete Option Failed in WebApi: {Environment.NewLine}Method: {Request.Method}{Environment.NewLine}URI: {Request.RequestUri}";
                _logger.Error(logmessage, (int)ApplicationEvent.DeleteOptionFailedEvent, null);
            }

            catch (Exception e)
            {
                var message =
                    $"Unhandled Exception occured in the Web API:{Environment.NewLine}Method: {Request.Method}{Environment.NewLine}URI: {Request.RequestUri} Exception: {e.GetType()}{Environment.NewLine}ExceptionMessage: {e.Message}{Environment.NewLine}Stack Trace: {e.StackTrace}";

                _logger.Error(message, (int)ApplicationEvent.UnhandledApplicationException, e);
            }

            return InternalServerError();
        }
    }
}
