using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Seguro.Company.Web.Startup))]
namespace Seguro.Company.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
