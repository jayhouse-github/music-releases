using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Music_Releases_Website.Startup))]
namespace Music_Releases_Website
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
