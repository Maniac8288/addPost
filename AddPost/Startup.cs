using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AddPost.Startup))]
namespace AddPost
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
           
        }
    }
}
