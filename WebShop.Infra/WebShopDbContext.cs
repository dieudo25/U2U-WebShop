using Microsoft.EntityFrameworkCore;
using WebShop.Core.Entities;
using WebShop.Infra.Configurations;

namespace WebShop.Infra
{
    public class WebShopDbContext : DbContext 
    {
        public WebShopDbContext(DbContextOptions<WebShopDbContext> options) : base(options) { } 

        public DbSet<Product> Products => Set<Product>();
        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        { 
            base.OnModelCreating(modelBuilder); 
            modelBuilder.ApplyConfiguration(new ProductConfiguration()); 
        } 
    }
}
