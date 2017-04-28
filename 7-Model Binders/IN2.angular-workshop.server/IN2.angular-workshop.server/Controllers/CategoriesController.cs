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
        public IHttpActionResult GetAllCategories()
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

                return Ok(categories);
            }
            catch (Exception exc)
            {
                return InternalServerError(exc);
            }
        }

        /// <summary>
        /// Returns products belonging to one category
        /// </summary>
        /// <param name="categoryId">Category Id</param>        
        [ActionName("get-products")]
        public IHttpActionResult GetProducts(int id)
        {            
            try
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

                return Ok(products);
            }
            catch(Exception exc)
            {
                return InternalServerError(exc);
            }
        }

        public IHttpActionResult PostCategory(Category category)
        {
            if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }
            try
            {
                //spremi kategoriju
                category.Id = 10;

                return Created(new Uri(Request.RequestUri, string.Format("category/{0}", category.Id)), category);
            }
            catch (Exception exc)
            {
                var message = string.Join(" | ", ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage));
                return InternalServerError(new Exception("Greška pri spremanju kategorije.", exc));
            }
        }

        public IHttpActionResult GetProductsForCategory([FromUri] Category category)
        {
            return Ok(category);
        }
    }
}