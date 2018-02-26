using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ArquiteturaDDD.MVC.Startup))]
namespace ArquiteturaDDD.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
           
        }
    }
}
