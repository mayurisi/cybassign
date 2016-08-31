using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Demo.WebApi2
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            //using mvc style routing
            config.Routes.MapHttpRoute(
              name: "MyApiRoute",
              routeTemplate: "{controller}/{action}/{id}",
              defaults: new { id = RouteParameter.Optional }
            );

            //default route for web api
            //config.Routes.MapHttpRoute(
            //    name: "DefaultApi",
            //    routeTemplate: "api/{controller}/{id}",
            //    defaults: new { id = RouteParameter.Optional }
            //);

          
        }
    }
}
