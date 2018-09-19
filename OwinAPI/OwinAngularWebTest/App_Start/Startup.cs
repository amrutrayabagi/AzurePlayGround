using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using System.Web.Http;
using System.Web.Routing;
using System.Web.Optimization;
using System.Web.Cors;

[assembly: OwinStartup(typeof(OwinAngularWebTest.App_Start.Startup))]

namespace OwinAngularWebTest.App_Start
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888
            var httpConfig = new HttpConfiguration
            {

            };


            WebApiConfig.Register(httpConfig);

           // app.UseWebApi(httpConfig);
            //app.UseCors(CorsOptions.AllowAll);

            RouteConfig.RegisterRoutes(RouteTable.Routes);//MVC Routing
            BundleConfig.RegisterBundles(BundleTable.Bundles);

        
        }
    }
}
