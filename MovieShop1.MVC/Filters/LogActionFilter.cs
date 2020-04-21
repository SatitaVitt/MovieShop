using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
//dont use http one, that is for web api

namespace MovieShop1.MVC.NewFolder1
{
    // ActionFilterAttribute
    // ExceptionFilterAttribute
    // AuthenticationFilterAttribute
    // AuthorizationFilterAttribute

    // Creating a custom Filter to log some information about user
    // like his/her browse, type of request, url he is accessing

    public class LogActionFilter: ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            //base.OnActionExecuted(filterContext);
            LogSomeInformation("OnActionExecuted", filterContext.RouteData);
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //base.OnActionExecuting(filterContext);
            LogSomeInformation("OnActionExecuting", filterContext.RouteData);
        }

        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            //base.OnResultExecuting(filterContext);
            LogSomeInformation("OnResultExecuting", filterContext.RouteData);
        }

        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            //base.OnResultExecuted(filterContext);
            LogSomeInformation("OnResultExecuted", filterContext.RouteData);
        }

        private void LogSomeInformation(string methodName, RouteData routeData)
        {
            //we can log this info to any text file using any 3rd party logging framework 
            // such as Nlog, SeriLong, Log4net
            var controllerName = routeData.Values["controller"];
            var actionName = routeData.Values["action"];
        }
    }
}