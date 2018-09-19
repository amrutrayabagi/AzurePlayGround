using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AzureSQLDatabase.Startup))]
namespace AzureSQLDatabase
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
