using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MVCSessionTagHelperViewComponent.Areas.Admin.Data;
using MVCSessionTagHelperViewComponent.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCSessionTagHelperViewComponent
{
    public class Startup
    {
        // ViewComponent
        // TagHelper
        // Session
        // Cache

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllersWithViews();
            services.AddRazorPages(); // razorpages ile de çalýþacaðýmýz için bu serviside aktif hale getiriyoruz.
            services.AddSession();
            services.AddTransient<IEmailSender, EmailSender>();

            //services.AddDbContext<AdminContext>(opt =>
            //{
            //    opt.UseSqlServer(Configuration.GetConnectionString("IdentityContextConnection"));
            //});
            
  
            //services.AddRazorPages().AddRazorRuntimeCompilation();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();


            app.UseRouting();
            // Eðer Login iþlemi yapýyorsa bu middleware çalýþtýrmamýz lazým
            app.UseAuthentication();
           
            app.UseAuthorization();


            app.UseSession();

            //app.UseBrowserLink();

            app.UseEndpoints(endpoints =>
            {

                // mvc ile bir area açarsak buraya areasname ile bir yönlendirme kuralý yazmamýz gerekiyor

                endpoints.MapAreaControllerRoute(
                 name: "Admin",
                 areaName: "Admin",
                 pattern: "Admin/{controller=Dashboard}/{action=Index}");


                //endpoints.MapAreaControllerRoute(
                //name: "HumanResource",
                //areaName: "HumanResource",
                //pattern: "HR/{controller=Home}/{action=Index}");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                // RazorPages sayfalarýnda Login Register var buraya tanýtmak lazým
                endpoints.MapRazorPages();
            });



        }
    }
}
