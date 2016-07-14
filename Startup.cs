using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WedMarch9.Startup))]
namespace WedMarch9
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
