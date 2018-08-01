using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EExpress.Startup))]
namespace EExpress
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
