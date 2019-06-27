using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AxosnetWebApi.Startup))]
namespace AxosnetWebApi
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
