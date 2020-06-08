using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LandRegistrationUI.Startup))]
namespace LandRegistrationUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
