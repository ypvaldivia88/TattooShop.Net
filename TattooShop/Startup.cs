using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TattooShop.Startup))]
namespace TattooShop
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
