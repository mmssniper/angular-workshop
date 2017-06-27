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
        /// <summary>
        /// Fetch all details of one product, but use directly Content Negotiator
        /// </summary>
        /// <param name="productId">Product Id</param>
        /// <returns>Returns requested product details</returns>
        public HttpResponseMessage GetProductDetails(int productId)
        {
            var product = new Product
            {
                Id = 1,
                Name = "Dummy product",
                Price = 10.00m,
                DateCreated = DateTime.Now
            };

            IContentNegotiator negotiator = this.Configuration.Services.GetContentNegotiator();

            ContentNegotiationResult result = negotiator.Negotiate(
                typeof(Product), this.Request, this.Configuration.Formatters);

            if (result == null)
            {
                //NO FORMATTER FOUND
                var response = new HttpResponseMessage(HttpStatusCode.NotAcceptable);
                throw new HttpResponseException(response);
            }

            return new HttpResponseMessage()
            {
                Content = new ObjectContent<Product>(
                    product,                // What we are serializing 
                    result.Formatter,           // The media formatter
                    result.MediaType.MediaType  // The MIME type
                )
            };
        }
    }
}
