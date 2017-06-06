using Microsoft.Owin;
using Owin;

[assembly: OwinStartup("Api",typeof(HortaApp.Api.Startup))]

namespace HortaApp.Api
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
