using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using IN2.angular_workshop.server.Models;
using System.Net.Http.Headers;

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
        public HttpResponseMessage GetProductDetails(int productId)
        {
            var response = Request.CreateResponse(HttpStatusCode.OK, 
                new Product
                {
                    Id = 1,
                    Name = "Dummy product",
                    Price = 10.00m,
                    DateCreated = DateTime.Now
                });

            response.Headers.CacheControl = new CacheControlHeaderValue()
            {
                NoCache = true
            };

            return response;
        }
    }
}
