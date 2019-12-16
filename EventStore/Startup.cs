using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EventStore.Startup))]
namespace EventStore
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
