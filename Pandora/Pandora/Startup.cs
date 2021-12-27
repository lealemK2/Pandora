using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Pandora.Startup))]
namespace Pandora
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
