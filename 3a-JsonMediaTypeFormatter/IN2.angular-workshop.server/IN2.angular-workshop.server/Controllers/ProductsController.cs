using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using IN2.angular_workshop.server.Models;
using System.Net.Http.Headers;
using System.Net.Http.Formatting;

namespace IN2.angular_workshop.server.Controllers
{
    public class ProductsController : ApiController
    {
        [ActionName("get-product-details")]
        public HttpResponseMessage GetProductDetails(int productId)
        {
            var product = new Product
            {
                Id = productId,
                Name = "Dummy product",
                Price = 10.00m,
                DateCreated = DateTime.Now
            };

            var response = Request.CreateResponse(HttpStatusCode.OK, product);

            return response;
        }
    }
}
