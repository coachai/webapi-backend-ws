using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;
using WebAPITest.Controllers;

namespace WebAPITest
{
    public class NotFoundException: Exception
    {
       public NotFoundException()
        { }

        public NotFoundException(string message)
            :base(message)
        { }

        public NotFoundException(string message,Exception inner)
            :base(message,inner)
        { }
    }
}