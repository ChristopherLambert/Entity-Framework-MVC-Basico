using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Expressos.Startup))]
namespace Expressos
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
