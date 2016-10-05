using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace MVCProject
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
        protected void Application_Error(object sender, EventArgs e)
        {
            var ex = Server.GetLastError() as HttpException;

            if (ex != null)
            {
                int errorCode = ex.GetHttpCode();

                if (errorCode == 404)
                {
                    Response.Redirect("~/Error/Error404Page");
                }
            }

            else
            {
                Response.Redirect("~/Error/ErrorPage");
            }
            

        }
    }
}
