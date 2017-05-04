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

***************************START 1a -- Attribute Routing********************************************************

1) omogućiti AttributeRouting
2) staviti RoutePrefix na controllere
3) staviti Route na akcije
***************************End 1a -- Attribute Routing********************************************************


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


****************START 4 - Exception Filteri - override default ponašanja *******************************************************************************************

1) OBJASNITI PROCES 
2) public class NotImplExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            if (actionExecutedContext.Exception is NotImplementedException)
            {
                actionExecutedContext.Response = new HttpResponseMessage(HttpStatusCode.NotImplemented);
            }
        }
    }
	
3) registrirati ga na akciji, controlleru-globalno
4) demonstirati na Products/GetAll

****************END 4 -  Exception Filteri - override default ponašanja *******************************************************************************************



****************5 - IHttpActionResult *******************************************************************************************

1) sve metode prebaciti na IHttpActionResult
1a) sve exception handlere prebaciti na InternalServerError-BadRequest

3a) Dodati ModelState.IsValid --> BadRequest
3b) ukrasiti model sa DataAnnotationom
3c) POST --> BadRequest, InternalServerError, Created (LOCATION)

4) dodati Required nad Category.Name --> testiranje json (Name:null) --> demonstrirati kako se serijalizira model state

5) DEMONSTRIRATI OVERPOSTING (ignoriranje ostalih parametara json-xml ---> uvijek samo primati skupinu parametara koji su dozvoljeni toj roli-akciji-procesu)

6) WEB API NEMA DEFAULT UGRAĐENU PODRŠKU ZA SERIJALIZACIJU MODEL STATEADodati
Dodati custom ValidateErrorAttribute u Filters folder
6a) registrirati u WebApiConfig --> Filters.Add(new ....)
6b) Testirati


7) dodati DecoratedTextResult(string value, HttpRequestMessage request) u Results direktorij--> 
7a) vratiti njega na products/getproductdetails?productId=1 
7b) provjeriti da se vraća npr. Accepted umjesto Ok-200


****************END 5 - IHttpActionResult *******************************************************************************************


****************START 6 - PARAMETER BINDING i TYPE CONVERTERI  *******************************************************************************************

1) dodati
public IHttpActionResult GetProductsForCategory([FromUri] Category category)
        {
            return Ok(category);
        }
2) testirati sa http://localhost:63286/api/categories/GetProductsForCategory?Id=1&Name="Dummy Product"

3) dodati ProductDiscount i pripadajući TypeConverter --> 
3a) GET public IHttpActionResult AddProductDiscount(ProductDiscount productDiscount) --> ZAŠTO NIKADA
3b) POST public IHttpActionResult AddProductDiscount(ProductDiscount productDiscount) --> ZAŠTO DA
****************END 6 - PARAMETER BINDING *******************************************************************************************


****************START 7 - MODEL BINDERS  *******************************************************************************************

1) kreirati ProductDiscountModelBinder
1a) testirati
1b) objasniti gdje se može primjeniti: parametar od akcije, povrh modela (isto kao TypeConv), globalno
var provider = new SimpleModelBinderProvider(
            typeof(GeoPoint), new GeoPointModelBinder());
        config.Services.Insert(typeof(ModelBinderProvider), 0, provider);
****************END 7 - MODEL BINDERS  *******************************************************************************************

****************START 8 - CORS  *******************************************************************************************
1) instalacija NuGet paketa Install-Package Microsoft.AspNet.WebApi.Cors
2)App_Start/WebApiConfig.cs. Add the following code to the WebApiConfig.Register 
// New code
config.EnableCors();
3) [EnableCors] attribute to the TestController class:
[EnableCors(origins: "http://mywebclient.azurewebsites.net", headers: "*", methods: "*")]
4) [DisableCors]
5) globalno enable corsa 
var cors = new EnableCorsAttribute("www.example.com", "*", "*");
config.EnableCors(cors);

****************END START 8 - CORS  *******************************************************************************************

****************START 9 - UNIT TESTING  *******************************************************************************************
1) dodati Services folder
2) kreirati  public interface ICategoryService
    {
        List<Category> GetAllCategories();
        List<Product> GetProductsForCategory(int categoryId);
    }
3) public interface IProductsService
    {
        Product GetProductById(int productId);
        List<Product> GetAllProducts();
    }
	
4) dodati u /Implementation podfolder implementacije

5) Install-Package Unity.WebAPI

6) zamijeniti direktnu implementaciju sa IProductsService i ICategoryService
6a) registrirati Unity-u

7) testirati


****************END 9 - UNIT TESTING  *******************************************************************************************

*****************START 10 - THE REAL DEAL****************************************************************************************
1) refactor
1a) kreirati Models projekt i prebaciti sve
ab) kreirati BAL projekt i prebaciti sve

2) testirati da radi
2a) vratiti se na testove i testirati da radi
*********************************************************************************************************************************
*********************************************************************************************************************************