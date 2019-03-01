using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Super_Hero_Project.Startup))]
namespace Super_Hero_Project
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
