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
    public class ProductsController : ApiController
    {
        /// <summary>
        /// Fetch all details of one product
        /// </summary>
        /// <returns></returns>
        public HttpResponseMessage GetProductDetails()
        {
            var response = Request.CreateResponse(HttpStatusCode.OK, 
                new Product
                {
                    Id = 1,
                    Name = "Dummy product",
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
