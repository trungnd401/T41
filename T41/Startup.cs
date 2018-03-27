using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(T41.Startup))]
namespace T41
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
