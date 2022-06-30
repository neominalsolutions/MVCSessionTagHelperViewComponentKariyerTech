using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MVCSessionTagHelperViewComponent.Areas.Admin.Data;
using MVCSessionTagHelperViewComponent.Areas.Identity.Data;
using MVCSessionTagHelperViewComponent.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MVCSessionTagHelperViewComponent.Controllers
{
    // [Authorize]
    // Bu controller'a sadece login olan erişebilir.
    // eğer login değilsek login sayfasına sistem otomatik olarak yönlendirecektir.


    public class HomeController : Controller
    {
    //private readonly ILogger<HomeController> _logger;
    //private readonly AdminContext _adminContext;
    //private readonly UserManager<ApplicationUser> _userManager;


        // ILogger<HomeController> logger, AdminContext adminContext, UserManager<ApplicationUser>  userManager
        public HomeController()
        {
        }
  
        public async Task<IActionResult> Index()
        {
           //var blog = _adminContext.Blogs.Find(2);
           //var user = await _userManager.FindByIdAsync(blog.UserId);

            return View();
        }

        // cookie üzerindeki bilgilerden çalışır
        // ilgili method üzerine bu attribute konulduğunda rol kontrolü yapar
        // istek tamamlanamazsa access denied sayfasına yönlendirir. 
        //[Authorize(Roles = "Admin")]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
