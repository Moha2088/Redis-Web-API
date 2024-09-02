using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Re_Test.Models;

namespace Re_Test.Data
{
    public class Re_TestContext : DbContext
    {
        public Re_TestContext (DbContextOptions<Re_TestContext> options)
            : base(options)
        {
        }

        public DbSet<Re_Test.Models.Product> Product { get; set; } = default!;
    }
}
