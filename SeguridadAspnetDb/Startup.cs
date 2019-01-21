using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SeguridadAspnetDb.Startup))]
namespace SeguridadAspnetDb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
