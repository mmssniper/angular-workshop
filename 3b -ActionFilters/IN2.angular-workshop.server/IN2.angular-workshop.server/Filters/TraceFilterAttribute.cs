using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace IN2.angular_workshop.server.Filters
{
    public class TraceFilterAttribute : ActionFilterAttribute
    {
        public TraceFilterAttribute()
        {

        }

        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            Trace.WriteLine(string.Format("Action Method {0} executing at {1} {2}", actionContext.ActionDescriptor.ActionName, DateTime.Now.ToShortDateString(), DateTime.Now.ToLongTimeString()), "Web API Audit");
        }

        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            Trace.WriteLine(string.Format("Action Method {0} executed at {1} {2}", actionExecutedContext.ActionContext.ActionDescriptor.ActionName, DateTime.Now.ToShortDateString(), DateTime.Now.ToLongTimeString()), "Web API Audit");
        }
    }
    
}