using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVCSessionTagHelperViewComponent.Models;
using MVCSessionTagHelperViewComponent.SessionExtension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCSessionTagHelperViewComponent.Controllers
{


    public class SessionController : Controller
    {

        //[Authorize]
        // Sadece Oturum açan kullanıclar anasayfayı görebilir.
        // kimlik doğrulamasına bakar.
        public IActionResult SetSession()
        {

            HttpContext.Session.SetString("deneme", HttpContext.Session.Id);
            HttpContext.Session.SetObject<Product>("ProductSession", new Product
            {
                Name = "P1",
                Description = "Deneme"
            });

            return View();
        }

        //[Authorize]
        // Sadece Oturum açan kullanıclar anasayfayı görebilir.
        // kimlik doğrulamasına bakar.
        // daha view açılmadan önce bu view yetki yoksa bu sayfa kullanıcıya gösterilemez.
        public IActionResult GetSession()
        {

        HttpContext.Session.Remove("deneme");

          ViewBag.Session =   HttpContext.Session.GetString("deneme");


            ViewBag.SessionProduct = HttpContext.Session.GetObject<Product>("ProductSession");


            return View();
        }
    }
}
