using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ModelsDemo.Startup))]
namespace ModelsDemo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
