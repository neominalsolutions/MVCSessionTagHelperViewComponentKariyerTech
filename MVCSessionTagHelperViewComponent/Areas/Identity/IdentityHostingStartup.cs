using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MVCSessionTagHelperViewComponent.Areas.Identity.Data;

[assembly: HostingStartup(typeof(MVCSessionTagHelperViewComponent.Areas.Identity.IdentityHostingStartup))]
namespace MVCSessionTagHelperViewComponent.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        // cookie based authentication
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {

                services.AddDbContext<IdentityContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("IdentityContextConnection")));

                // eğer sistemde identity kullanılacak ise bu servis olarak aşağıdaki ekliyoruz.
                services.AddIdentity<ApplicationUser, ApplicationRole>(options =>
                {
                    options.SignIn.RequireConfirmedAccount = true;
                    options.SignIn.RequireConfirmedEmail = true;
                    options.SignIn.RequireConfirmedPhoneNumber = false;
                    options.Password.RequireDigit = true;
                    options.Password.RequireLowercase = true;
                    options.Password.RequiredLength = 12;
                    options.Password.RequireNonAlphanumeric = true;
                    options.User.RequireUniqueEmail = true;
                    // 2 dk içerisinde 6 adet hata yaparsa
                    options.Lockout.MaxFailedAccessAttempts = 6;
                    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(2);

                }).AddEntityFrameworkStores<IdentityContext>().AddDefaultTokenProviders();



                services.ConfigureApplicationCookie(opt =>
                {
                    opt.LoginPath = new PathString("/Identity/Account/Login");
                    opt.AccessDeniedPath = new PathString("/Identity/Account/AccessDenied");
                    opt.LogoutPath = new PathString("/Identity/Account/Logout");
                    opt.Cookie = new CookieBuilder
                    {
                        Name = "TestCookie", //Oluşturulacak Cookie'yi isimlendiriyoruz.
                        HttpOnly = false, // Https serfikamız varsa cookie saldırı yapacak kullanıcılar erşimesin diye koyduğumuz ayar.
                    };
                    opt.SlidingExpiration = true; //Expiration süresinin yarısı kadar süre zarfında istekte bulunulursa eğer geri kalan yarısını tekrar sıfırlayarak ilk ayarlanan süreyi tazeleyecektir.
                    // Rememberme false ise bu ayar geçerli olamaz, cookie kalıcı olarak oluşmalıdır. Oturum süresince oluşmamalıdır.
                    opt.ExpireTimeSpan = TimeSpan.FromDays(40); // 40 günlük çerez oluşturduk logout olmayana kadar bu cookie değerini koruyoruz.
                });

            });


        

        }
    }
}