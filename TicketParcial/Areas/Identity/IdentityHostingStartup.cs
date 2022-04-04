using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TicketParcial.Areas.Identity.Data;
using TicketParcial.Data;

[assembly: HostingStartup(typeof(TicketParcial.Areas.Identity.IdentityHostingStartup))]
namespace TicketParcial.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<TicketParcialDBContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("TicketParcialDBContextConnection")));

                services.AddDefaultIdentity<TicketParcialUser>(options => options.SignIn.RequireConfirmedAccount = false)
                    .AddEntityFrameworkStores<TicketParcialDBContext>();
            });
        }
    }
}