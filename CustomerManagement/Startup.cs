using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CustomerManagement.Startup))]
namespace CustomerManagement
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
