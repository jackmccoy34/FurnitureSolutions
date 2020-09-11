using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FurnitureSolutions.Startup))]
namespace FurnitureSolutions
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
