using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WhosTheExpert.Data;

[assembly: HostingStartup(typeof(WhosTheExpert.Areas.Identity.IdentityHostingStartup))]
namespace WhosTheExpert.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<WhosTheExpertContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("WhosTheExpertContextConnection")));

                services.AddDefaultIdentity<IdentityUser>()
                    .AddEntityFrameworkStores<WhosTheExpertContext>();
            });
        }
    }
}