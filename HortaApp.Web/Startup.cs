using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute("Web",typeof(HortaApp.Web.Startup))]
namespace HortaApp.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
