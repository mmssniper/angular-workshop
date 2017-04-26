1) Kreiranje Empty Web Projekta sa Web API podrškom
2) Kreiranje ProductsControllera
3) Kreiranje Product modela u Models direktoriju
4) Kreiranje metode GetProductDetails() --> new NotImplementedException() -->
5) testiranje u Postmanu ili Chrome Dev Tools
5a) config.IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.None vs IncludeErrorDetailPolicy.LocalOnly;

6) kreirati i vratiti klijentu dummy products
6a) promijeniti u WebAPIConfigu IncludeErrorDetailPolicy.LocalOnly;

7) testirati i pokazati Accept (media type formatter) za xml i json na djelu (kroz POSTMAN)

8) prelazak na HttpResponseMessage (Request.CreateResponse(HttpStatusCode.Ok, new ....
9) testiranje xml - json

**ISKLJUČITI VS IE-Chrome js Debugging **
