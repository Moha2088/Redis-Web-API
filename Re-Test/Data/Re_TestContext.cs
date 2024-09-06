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

        protected override void OnModelCreating(ModelBuilder builder)
        {          
            var productEntity = builder.Entity<Product>();
            productEntity.HasKey(x => x.Id);
            productEntity.Property(x => x.Name).HasColumnType("nvarchar(256)");
            productEntity.Property(x => x.Price).HasColumnType("decimal");
            productEntity.HasIndex(x => x.Id);
  
        }

        public DbSet<Re_Test.Models.Product> Product { get; set; } = default!;
    }
}
