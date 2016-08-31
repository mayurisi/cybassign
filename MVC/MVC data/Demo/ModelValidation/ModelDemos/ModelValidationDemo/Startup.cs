using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ModelValidationDemo.Startup))]
namespace ModelValidationDemo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
