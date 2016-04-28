using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RentBoat.WebSite.Startup))]
namespace RentBoat.WebSite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
