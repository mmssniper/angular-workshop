using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Net.Http.Headers;
using IN2.angular_workshop.server.Results;
using System.Web.Http.ModelBinding;
using IN2.angular_workshop.server.ModelBinders;
using IN2.angular_workshop.server.Models;
using IN2.angular_workshop.server.Services;

namespace IN2.angular_workshop.server.Controllers
{
    [RoutePrefix("api/products")]
    public class ProductsController : ApiController
    {
        private readonly IProductsService _productService;

        public ProductsController(IProductsService productService)
        {
            _productService = productService;
        }

        /// <summary>
        /// Fetch all details of one product
        /// </summary>
        /// <param name="productId">Product Id</param>
        /// <returns>Returns requested product details</returns>
        [Route("get-product-details/{productId:int}")]
        public IHttpActionResult GetProductDetails(int productId)
        {
            try
            {
                var product = _productService.GetProduct(productId);

                if (product == null)
                {
                    return NotFound();
                }

                return Ok(product);
            }
            catch(Exception exc)
            {
                return InternalServerError(exc);
            }
        }

        [Route("get-bestselling")]
        public IHttpActionResult GetTopThreeBestSellers()
        {
            try
            {
                var products = _productService.GetBestSellingProducts();

                return Ok(products);
            }
            catch (Exception exc)
            {
                return InternalServerError(exc);
            }
        }


        [HttpPost]
        [Authorize]
        [Route("save-product")]
        public IHttpActionResult AddProductDiscount([ModelBinder(typeof(ProductDiscountModelBinder))] ProductDiscount productDiscount)
        {
            return Ok();
        }
    }
}
