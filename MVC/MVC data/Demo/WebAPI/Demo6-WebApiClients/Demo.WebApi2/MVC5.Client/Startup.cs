using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVC5.Client.Startup))]
namespace MVC5.Client
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
