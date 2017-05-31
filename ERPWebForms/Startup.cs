using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ERPWebForms.Startup))]
namespace ERPWebForms
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
