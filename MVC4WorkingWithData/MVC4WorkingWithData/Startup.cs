using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVC4WorkingWithData.Startup))]
namespace MVC4WorkingWithData
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
