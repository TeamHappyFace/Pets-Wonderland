using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PetsWonderland.Client.Startup))]

namespace PetsWonderland.Client
{
    public partial class Startup {
        public void Configuration(IAppBuilder app)
        {
            this.ConfigureAuth(app);
        }
    }
}
