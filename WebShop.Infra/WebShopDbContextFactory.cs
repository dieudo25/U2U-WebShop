using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace WebShop.Infra
{
    public class WebShopDbContextFactory : IDesignTimeDbContextFactory<WebShopDbContext>
    {
        public WebShopDbContext CreateDbContext(string[] args)
        {
            // This project should use the same user secrets key as the main .csproj !!!
            ConfigurationBuilder? cb = new ConfigurationBuilder(); 
            cb.AddUserSecrets<WebShopDbContext>(); 
            IConfigurationRoot configuration = cb.Build(); 
            string connectionString = configuration.GetConnectionString("WebShopDb"); 
            DbContextOptionsBuilder<WebShopDbContext>? builder = new DbContextOptionsBuilder<WebShopDbContext>(); 
            builder.UseSqlServer(connectionString); 
            builder.EnableSensitiveDataLogging(); 
            return new WebShopDbContext(builder.Options);
        }
    }
}
