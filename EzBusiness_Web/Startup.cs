using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EzBusiness_Web.Startup))]
namespace EzBusiness_Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
