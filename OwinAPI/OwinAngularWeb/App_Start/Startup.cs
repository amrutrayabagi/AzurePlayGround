using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using Microsoft.Owin.Builder;
using System.Web.Mvc;
using System.Web.Routing;

[assembly: OwinStartup(typeof(OwinAngularWeb.Startup))]
namespace OwinAngularWeb
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888
            // New code:

            //AreaRegistration.RegisterAllAreas();
            //////  FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            //RouteConfig.RegisterRoutes(RouteTable.Routes);

            //GlobalConfiguration.Configure(RouteConfig.RegisterRoutes(RouteTable.Routes));
            //GlobalConfiguration.Configuration.EnsureInitialized();
        }


    }
}
