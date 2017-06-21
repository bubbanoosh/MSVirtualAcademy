using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCWorkingWithData_2.Startup))]
namespace MVCWorkingWithData_2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
