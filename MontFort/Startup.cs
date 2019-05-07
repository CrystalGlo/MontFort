using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MontFort.Startup))]
namespace MontFort
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
