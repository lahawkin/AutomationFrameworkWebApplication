using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AutomationFrameworkWebApplication.Startup))]
namespace AutomationFrameworkWebApplication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
