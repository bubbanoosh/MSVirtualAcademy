using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Indentity.Startup))]
namespace Indentity
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
