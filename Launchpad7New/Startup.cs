using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Launchpad7New.Startup))]
namespace Launchpad7New
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
