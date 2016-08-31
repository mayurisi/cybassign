using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HelloMvcDemo.Startup))]
namespace HelloMvcDemo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
