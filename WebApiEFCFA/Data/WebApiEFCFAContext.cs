using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApiEFCFA.Model;

namespace WebApiEFCFA.Data
{
    public class WebApiEFCFAContext : DbContext
    {
        public WebApiEFCFAContext (DbContextOptions<WebApiEFCFAContext> options)
            : base(options)
        {
        }

        public DbSet<WebApiEFCFA.Model.Employee> Employee { get; set; } = default!;
    }
}
