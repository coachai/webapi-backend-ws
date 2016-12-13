using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using WebAPITest.Controllers;

namespace WebAPITest
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            ProductsController oneProductsController = new ProductsController();
            oneProductsController.InitializeSampleData();
        }
    }
}
