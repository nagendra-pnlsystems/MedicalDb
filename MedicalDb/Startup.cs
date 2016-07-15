using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MedicalDb.Startup))]
namespace MedicalDb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
