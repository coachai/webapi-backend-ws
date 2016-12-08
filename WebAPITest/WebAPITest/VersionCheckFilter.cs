using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Web.Http.Results;

namespace WebAPITest
{
    public class VersionCheckFilter : IActionFilter
    {
        public bool AllowMultiple
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public async Task<HttpResponseMessage> ExecuteActionFilterAsync(HttpActionContext actionContext, CancellationToken cancellationToken, Func<Task<HttpResponseMessage>> continuation)
        {
            // 1. Stuff you do here will happen before the controller action method 
              Debug.WriteLine("Before controller method - First filter");
             HttpResponseMessage response = null;
            var versionheaders =actionContext.Request.Headers.Where(h => h.Key == "X-Version");
            if (versionheaders.Any())
            { var firstheader = versionheaders.First();
                var version = firstheader.Value.FirstOrDefault();
                if (version != null && version == "42")
                { response = await continuation();
                }
                
            }
            if (response == null)
            {
                var result = new StatusCodeResult((HttpStatusCode)418, actionContext.Request);
                response = await result.ExecuteAsync(cancellationToken);
            }

            return response;


             // 2. Now we send the request to the next link in the chain of filters 
             // (or to the controller if we are at the end) 

            


             // 3. Stuff you do here will happen after the controller action method 
             Debug.WriteLine("After controller method - First filter");
            


             // 4. Return response thereby continuing back up the chain of filters 
             return response;


        }
    }
}