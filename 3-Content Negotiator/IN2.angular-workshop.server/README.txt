****************1 - CONTROLLERS i ROUTING*******************************************************************************************
1) Kreiranje Empty Web Projekta sa Web API podrškom

2) Kreiranje CategoriesControllera
2a) Kreiranje metode void GetAllCategories() --> new NotImplementedException() -->
2b) TESTIRANJE REZULTATA (testiranje u Postmanu ili Chrome Dev Tools)
2c)config.IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.None vs IncludeErrorDetailPolicy.LocalOnly;
(promijeniti u WebAPIConfigu IncludeErrorDetailPolicy.LocalOnly)

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

rezultat: /api/categories
/api/categories/1

2d) pokazati razliku vezano za ActionName + parametre (id vs categoryId) + u ruting tablici dodati {action}

3) Kreiranje praznog ProductsControllera
3a) Kreiranje Product modela u Models direktoriju (Id, Name, Price, DateCreated)
3b) Kreiranje metode GetProductDetails(id:int) 
3c) kreirati i vratiti klijentu dummy products
3d) testirati i pokazati Accept (media type formatter) za xml i json na djelu (kroz POSTMAN)


4) Kreiranje Category klase (Id, Name, Products::List<Product>)
CategoriesController --> Kreiranje metode GetCategoryDetails(id) --> vraća 2 kategorije
 
5b) testirati i pokazati Accept (media type formatter) za xml i json na djelu (kroz POSTMAN)

**ISKLJUČITI VS IE-Chrome js Debugging **
*************************END 1 - CONTROLLERS i ROUTING***********************************************************


****************2 - HttpResponseMessage*******************************************************************************************
1) CategoriesController - (već kreirani Category i Product klase)
2) dodati ActionName povrh svake sa povratnim rezultatima (razdvajanje sa -)

2a) dodati na CategoriesController implementaciju metoda koja vraća dummy vrijednosti
		/// <summary>
        /// Returns all existing categories in the system
        /// </summary>
        [ActionName("get-all-categories")]
        public List<Category> GetAllCategories()
        {
            return new List<Category>()
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
        }


        /// <summary>
        /// Returns products belonging to one category
        /// </summary>
        /// <param name="categoryId">Category Id</param>        
        [ActionName("get-products")]
        public List<Product> GetProducts(int id)
        {
            return new List<Product>()
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
        }
    }
3) prebaciti sve na HttpResponseMessage (Request.CreateResponse(Ok, products-categories)
3a) testirati

4) dodati try-catch na jednu metodu i onda dodati Request.CreateErrorResponse (upravljanje StatusCodovima, NotFound,BadRequest,InternalServerError, Unathorized,Forbidden,MethodNotAllowed...)
4a) namjerno dodati throw throw new ApplicationException("test exceptiona...");            || throw new HttpResponseException(HttpStatusCode.NotFound);

5) Dodati POST (Category) --> pokazati kako funkcionira
5a) Demonstrirati Location Header (201) - response.Headers.Location
var response = Request.CreateResponse(HttpStatusCode.Created, category);
response.Headers.Location = new Uri(Request.RequestUri, string.Format("category/{0}", category.Id));
	
****************END 2 - HttpResponseMessage*******************************************************************************************

****************START 3 - ContentNegotiator i Custom Type Formatteri *******************************************************************************************

1) OBJASNITI PROCES 
2) implementirati - demonstrirati kako se može upravljati sa Content Negotiatorom direktno

****************END 3 -  ContentNegotiator i Custom Type Formatteri *******************************************************************************************

