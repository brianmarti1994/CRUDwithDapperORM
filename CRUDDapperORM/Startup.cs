using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CRUDDapperORM.Startup))]
namespace CRUDDapperORM
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
