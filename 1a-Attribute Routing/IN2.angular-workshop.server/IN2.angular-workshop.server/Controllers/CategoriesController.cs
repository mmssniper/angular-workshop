using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace IN2.angular_workshop.server.Controllers
{
    [RoutePrefix("api/categories")]
    public class CategoriesController : ApiController
    {
        /// <summary>
        /// Returns all existing categories in the system
        /// </summary>
        [Route("get-all-categories")]
        public void GetAllCategories()
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// Returns products belonging to one category
        /// </summary>
        /// <param name="categoryId">Category Id</param>        
        [Route("get-products/{categoryId:int}")]
        //[Route("get-products/{id:int:min(1)}")]
        public void GetProducts(int categoryId)
        {
            throw new NotImplementedException();
        }
    }
}
