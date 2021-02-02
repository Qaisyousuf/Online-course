using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OnlineTrainingWeb.Startup))]
namespace OnlineTrainingWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
