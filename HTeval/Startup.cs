using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HTeval.Startup))]
namespace HTeval
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
