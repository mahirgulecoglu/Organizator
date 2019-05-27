using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Organizator.Startup))]
namespace Organizator
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
