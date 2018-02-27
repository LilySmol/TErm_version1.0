using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TErm.Startup))]
namespace TErm
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
