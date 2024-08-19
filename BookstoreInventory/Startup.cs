using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(BookstoreInventory.StartupOwin))]

namespace BookstoreInventory
{
    public partial class StartupOwin
    {
        public void Configuration(IAppBuilder app)
        {
            //AuthStartup.ConfigureAuth(app);
        }
    }
}
