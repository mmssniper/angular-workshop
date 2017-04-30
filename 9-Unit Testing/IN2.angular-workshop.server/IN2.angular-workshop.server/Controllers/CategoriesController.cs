using IN2.angular_workshop.server.Models;
using IN2.angular_workshop.server.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace IN2.angular_workshop.server.Controllers
{
    [RoutePrefix("api/categories")]
    public class CategoriesController : ApiController
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        /// <summary>
        /// Returns all existing categories in the system
        /// </summary>
        [Route("get-all-categories")]
        public IHttpActionResult GetAllCategories()
        {
            try
            {
                var categories = _categoryService.GetAllCategories();

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
        [Route("get-products/{id:int:min(1)}")]
        //[DisableCors]
        public IHttpActionResult GetProducts(int id)
        {            
            try
            {
                var productsForCategory = _categoryService.GetProductsForCategory(id);

                return Ok(productsForCategory);
            }
            catch(Exception exc)
            {
                return InternalServerError(exc);
            }
        }

        [HttpGet]
        [Route("get-category-details/{categoryId:int:min(1)}")]
        public IHttpActionResult GetCategory(int categoryId)
        {
            try
            {
                var category = _categoryService.GetCategory(categoryId);

                if (category != null)
                {
                    return Ok(category);
                }

                return NotFound();
            }
            catch (Exception exc)
            {
                return InternalServerError(exc);
            }
        }

        [HttpPost]
        [Route("save-category")]
        public IHttpActionResult SaveCategory(Category category)
        {
            if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var savedCategory = _categoryService.Save(category);

                return Created(new Uri(Request.RequestUri, string.Format("category/{0}", savedCategory.Id)), savedCategory);
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