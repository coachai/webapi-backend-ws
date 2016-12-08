using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;

namespace WebAPITest
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.Filters.Add(new VersionCheckFilter());
            config.MapHttpAttributeRoutes();
            config.Services.Replace(typeof(IExceptionHandler),new NotFoundHandler());

            config.Routes.MapHttpRoute(
                name: "defaultapi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
