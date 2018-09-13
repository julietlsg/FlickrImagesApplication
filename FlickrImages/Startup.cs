using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FlickrImages.Startup))]
namespace FlickrImages
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
