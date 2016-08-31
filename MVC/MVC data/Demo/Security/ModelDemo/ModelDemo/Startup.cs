using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ModelDemo.Startup))]
namespace ModelDemo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
