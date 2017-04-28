using IN2.angular_workshop.server.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace IN2.angular_workshop.server
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            // koliko će Web API biti verbose sa greškama
            config.IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.LocalOnly;

            config.Filters.Add(new ValidateErrorAttribute());

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
