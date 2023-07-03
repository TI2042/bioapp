//using System;
//using BioApp.Data;
//using BioApp.Models;
//using Microsoft.AspNetCore.Authentication.Cookies;
//using Microsoft.AspNetCore.Hosting;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Identity.UI;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.DependencyInjection;

//[assembly: HostingStartup(typeof(BioApp.Areas.Identity.IdentityHostingStartup))]
//namespace BioApp.Areas.Identity
//{
//    public class IdentityHostingStartup : IHostingStartup
//    {
//        public void Configure(IWebHostBuilder builder)
//        {
//            builder.ConfigureServices((context, services) => {
//                services.AddDbContext<BioContext>(options =>
//                    options.UseSqlServer(
//                        context.Configuration.GetConnectionString("DefaultConnection")));

//                //services.AddDefaultIdentity<AppUser>()
//                //    .AddRoles<IdentityRole>()
//                //    .AddEntityFrameworkStores<BioContext>();
//                //services.AddIdentity<IdentityUser, IdentityRole>(options =>
//                //{
//                //    options.User.RequireUniqueEmail = false;
//                //})
//                //.AddEntityFrameworkStores<BioContext>()
//                //.AddDefaultTokenProviders();

//                //services.AddIdentity<AppUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true)
//                //        .AddEntityFrameworkStores<BioContext>()
//                //        .AddDefaultTokenProviders();

//                //services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
//                //    .AddCookie(options => //CookieAuthenticationOptions
//                //    {
//                //        options.LoginPath = new Microsoft.AspNetCore.Http.PathString("/Account/Login");
//                //    });


//                //services.AddIdentity<IdentityUser, IdentityRole>()
//                //.AddEntityFrameworkStores<BioContext>();

//            });
//        }
//    }
//}