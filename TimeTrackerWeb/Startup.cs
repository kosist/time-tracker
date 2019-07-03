using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TimeTrackerWeb.Startup))]
namespace TimeTrackerWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
