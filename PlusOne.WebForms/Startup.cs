using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PlusOne.WebForms.Startup))]
namespace PlusOne.WebForms
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
