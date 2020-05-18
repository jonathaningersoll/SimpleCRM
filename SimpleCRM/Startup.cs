using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SimpleCRM.Startup))]
namespace SimpleCRM
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
