using Microsoft.AspNetCore.Mvc;
using MVCSessionTagHelperViewComponent.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCSessionTagHelperViewComponent.ViewComponents
{
    public class MenuViewComponent: ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = new List<MenuViewModel>
            {
                new MenuViewModel
                {
                     AreaName =string.Empty,
                    ActionName = "Index",
                    ControllerName = "Home",
                    Title= "Anasayfa"
                },
                new MenuViewModel
                {
                     AreaName =string.Empty,
                  ActionName = "Privacy",
                  ControllerName = "Home",
                  Title = "Gizlilik"
                },
                 new MenuViewModel
                {
                      AreaName =string.Empty,
                  ActionName = "SetSession",
                  ControllerName = "Session",
                  Title = "Oturum Kaydet"
                },
                  new MenuViewModel
                {
                       AreaName =string.Empty,
                  ActionName = "GetSession",
                  ControllerName = "Session",
                  Title = "Oturum Getir"
                },
                     new MenuViewModel
                {
                         AreaName ="Identity",
                  ActionName = "Logout",
                  ControllerName = "Account",
                  Title = "Oturumdan Çık"
                },
                new MenuViewModel
                {
                         AreaName ="Admin",
                  ActionName = "Dashboard",
                  ControllerName = "Index",
                  Title = "Admin Module"
                }
            };

            return View(await Task.FromResult(model));
        }
    }
}
