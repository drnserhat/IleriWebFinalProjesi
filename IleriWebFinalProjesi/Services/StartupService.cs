
using IleriWebFinalProjesi.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace IleriWebFinalProjesi.Services
{
    public static class StartupService
    {

        public static void AddServices(this IServiceCollection services)
        {
            services.AddDbContext<MyDbContext>(options => options.UseSqlServer(Configuration.ConnectionString));

            services.AddControllersWithViews().AddRazorRuntimeCompilation();


        }
    }
}
