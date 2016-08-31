using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AreaDemo.Startup))]
namespace AreaDemo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
