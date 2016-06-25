using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MantenimientoCliente.Startup))]
namespace MantenimientoCliente
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
