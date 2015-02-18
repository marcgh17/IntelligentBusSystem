using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(IntelligentBusSystem.Startup))]
namespace IntelligentBusSystem
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //GitHubTest
            //GithubTest hoda
            ConfigureAuth(app);
            //test comment2
        }
    }
}
