using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProjetClassiqueWeb.Startup))]
namespace ProjetClassiqueWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
