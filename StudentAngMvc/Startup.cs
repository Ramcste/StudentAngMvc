using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(StudentAngMvc.Startup))]
namespace StudentAngMvc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
