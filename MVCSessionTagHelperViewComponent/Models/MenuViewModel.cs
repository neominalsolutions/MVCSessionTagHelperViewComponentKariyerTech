using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCSessionTagHelperViewComponent.Models
{
    public class MenuViewModel
    {
        public string AreaName { get; set; }

        public string ActionName { get; set; }
        public string ControllerName { get; set; }

        public string Title { get; set; }

    }
}
