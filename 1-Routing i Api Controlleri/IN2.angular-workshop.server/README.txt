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
*********************************************************************************************************