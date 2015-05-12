using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GreensheetExercise.Startup))]
namespace GreensheetExercise
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
