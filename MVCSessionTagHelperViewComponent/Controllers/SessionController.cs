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


      var model = new MenuViewModel();
      model.Title = "Menu1";
      model.ActionName = "Index";
      model.ControllerName = "Home";
      model.AreaName = "";

      var model2 = new MenuViewModel();
      model2.Title = "Menu2";
      model2.ActionName = "Privacy";
      model2.ControllerName = "Home";
      model2.AreaName = "";

      var menuList = new List<MenuViewModel>();
      menuList.Add(model);
      menuList.Add(model2);


      return View(menuList);
    }

    //[Authorize]
    // Sadece Oturum açan kullanıclar anasayfayı görebilir.
    // kimlik doğrulamasına bakar.
    // daha view açılmadan önce bu view yetki yoksa bu sayfa kullanıcıya gösterilemez.
    public IActionResult GetSession()
    {

      HttpContext.Session.Remove("deneme");

      ViewBag.Session = HttpContext.Session.GetString("deneme");


      ViewBag.SessionProduct = HttpContext.Session.GetObject<Product>("ProductSession");


      return View();
    }
  }
}
