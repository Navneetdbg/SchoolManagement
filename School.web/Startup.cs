using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(School.web.Startup))]
namespace School.web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
