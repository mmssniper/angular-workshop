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
        public void GetAllCategories()
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// Returns products belonging to one category
        /// </summary>
        /// <param name="categoryId">Category Id</param>        
        public void GetProducts(int id)
        {
            throw new NotImplementedException();
        }
    }
}
