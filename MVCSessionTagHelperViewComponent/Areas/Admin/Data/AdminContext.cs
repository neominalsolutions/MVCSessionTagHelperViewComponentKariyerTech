using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCSessionTagHelperViewComponent.Areas.Admin.Data
{
    public class AdminContext: DbContext
    {

        public AdminContext(DbContextOptions<AdminContext> dbContextOptions):base(dbContextOptions)
        {

        }
        public DbSet<Blog> Blogs { get; set; }

    }
}
