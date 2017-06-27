****************START 3b - Action Filters *******************************************************************************************

1) kreirati direktorij Filters
2) kreirati Action Filter klasu (nasljeđivanje od ActionFilterAttribute) - public class TraceFilterAttribute : ActionFilterAttribute
3) dodati povrh CategoryControllera --> [TraceFilter]

4) kreirati public class Trace2FilterAttribute : Attribute, IActionFilter
5) implementirati
6) primjeniti povrh ProductsControllera
****************END 3b - Action Filters *******************************************************************************************

