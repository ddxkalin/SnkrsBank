using Microsoft.AspNetCore.Hosting;
[assembly: HostingStartup(typeof(SnkrsBank.Web.Areas.Identity.IdentityHostingStartup))]

namespace SnkrsBank.Web.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
            });
        }
    }
}