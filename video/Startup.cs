using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(video.Startup))]
namespace video
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
