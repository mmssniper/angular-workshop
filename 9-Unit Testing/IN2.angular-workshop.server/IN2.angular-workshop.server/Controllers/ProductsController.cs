using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using IN2.angular_workshop.server.Models;
using System.Net.Http.Headers;
using IN2.angular_workshop.server.Results;
using System.Web.Http.ModelBinding;
using IN2.angular_workshop.server.ModelBinders;

namespace IN2.angular_workshop.server.Controllers
{
    [RoutePrefix("api/products")]
    public class ProductsController : ApiController
    {
        /// <summary>
        /// Fetch all details of one product
        /// </summary>
        /// <param name="productId">Product Id</param>
        /// <returns>Returns requested product details</returns>
        [Route("get-product-details/{productId:int}")]
        public IHttpActionResult GetProductDetails(int productId)
        {
            var product = new Product
                {
                    Id = 1,
                    Name = "Dummy product",
                    Price = 10.00m,
                    DateCreated = DateTime.Now
                };

            return new DecoratedTextResult(product.Name, Request);
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
