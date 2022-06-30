using MVCSessionTagHelperViewComponent.Areas.Identity.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCSessionTagHelperViewComponent.Areas.Admin.Data
{
    public class Blog
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public string UserId { get; set; }


        // Bu blog Bu user ait
    }
}
