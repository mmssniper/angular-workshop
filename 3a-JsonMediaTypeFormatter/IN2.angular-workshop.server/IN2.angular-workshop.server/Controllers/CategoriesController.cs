using IN2.angular_workshop.server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace IN2.angular_workshop.server.Controllers
{
    public class CategoriesController : ApiController
    {
        /// <summary>
        /// Returns all existing categories in the system
        /// </summary>
        [ActionName("get-all-categories")]
        public HttpResponseMessage GetAllCategories()
        {            
            try
            {
                var categories = new List<Category>()
            {
                new Category
                {
                    Id = 1,
                    Name = "Jazz"
                },
                new Category
                {
                    Id = 2,
                    Name = "Rock"
                },
                new Category
                {
                    Id = 3,
                    Name = "Classic"
                },
                new Category
                {
                    Id  = 4,
                    Name = "Modern"
                }
            };

                //throw new ApplicationException("test exceptiona...");            
                //throw new HttpResponseException(HttpStatusCode.NotFound);
                //throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));

                //DODATI THROW NEW EXCEPTION!!!
                return Request.CreateResponse(HttpStatusCode.OK, categories);
            }
            catch(Exception exc)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, exc);
            }
        }

        /// <summary>
        /// Returns products belonging to one category
        /// </summary>
        /// <param name="categoryId">Category Id</param>        
        [ActionName("get-products")]
        public HttpResponseMessage GetProducts(int id)
        {
            var products = new List<Product>()
            {
                new Product
                {
                    Id = 1,
                    Name = "Delicate Soundes of Thunder",
                    Price = 25
                },
                new Product
                {
                    Id = 2,
                    Name = "Weeknd",
                    Price = 15
                }
            };

            return Request.CreateResponse(HttpStatusCode.OK, products);
        }

        public HttpResponseMessage PostCategory(Category category)
        {
            //spremi kategoriju
            category.Id = 10;

            var response = Request.CreateResponse(HttpStatusCode.Created, category);
            response.Headers.Location = new Uri(Request.RequestUri, string.Format("category/{0}", category.Id));

            return response;
        }
    }
}
