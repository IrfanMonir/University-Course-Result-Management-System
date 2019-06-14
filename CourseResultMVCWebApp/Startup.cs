using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CourseResultMVCWebApp.Startup))]
namespace CourseResultMVCWebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
