using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace OwinApi
{
    public class StartUp
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            //// Configure Web API for self-host. 
            HttpConfiguration config = new HttpConfiguration();
            WebApiConfig.Register(config);
            appBuilder.UseWebApi(config);


        }
    }
}