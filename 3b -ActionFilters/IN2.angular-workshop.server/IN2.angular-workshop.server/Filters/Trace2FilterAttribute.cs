using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace IN2.angular_workshop.server.Filters
{
    public class Trace2FilterAttribute : Attribute, IActionFilter
    {
        public bool AllowMultiple
        {
            get
            {
                return true;
            }
        }

        public Task<HttpResponseMessage> ExecuteActionFilterAsync(HttpActionContext actionContext, CancellationToken cancellationToken, Func<Task<HttpResponseMessage>> continuation)
        {
            Trace.WriteLine(string.Format("Action Method {0} executing at {1} {2}", actionContext.ActionDescriptor.ActionName, DateTime.Now.ToShortDateString(), DateTime.Now.ToLongTimeString()), "Web API Audit");

            var result = continuation();

            result.Wait();

            Trace.WriteLine(string.Format("Action Method {0} executed at {1} {2}", actionContext.ActionDescriptor.ActionName, DateTime.Now.ToShortDateString(), DateTime.Now.ToLongTimeString()), "Web API Audit");

            return result;
        }
    }
}