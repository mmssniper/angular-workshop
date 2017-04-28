using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using IN2.angular_workshop.server.Models;
using System.Net.Http.Headers;
using System.Net.Http.Formatting;
using IN2.angular_workshop.server.Filters;

namespace IN2.angular_workshop.server.Controllers
{
    public class ProductsController : ApiController
    {
        /// <summary>
        /// Fetch all details of one product, but use directly Content Negotiator
        /// </summary>
        /// <param name="productId">Product Id</param>
        /// <returns>Returns requested product details</returns>
        public HttpResponseMessage GetProductDetails(int productId)
        {
            return Request.CreateResponse(HttpStatusCode.OK, new Product
            {
                Id = 1,
                Name = "Dummy product",
                Price = 10.00m,
                DateCreated = DateTime.Now
            });
        }

        //[NotImplExceptionFilter]
        public HttpRequestMessage GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
