using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using WebShop.Core.Entities;

namespace WebShop.Infra.Configurations; 

internal class ProductConfiguration : IEntityTypeConfiguration<Product> 
{ 
    public void Configure(EntityTypeBuilder<Product> product) 
    {
        product.HasKey(p => p.ProductId); 
        product.Property(p => p.Name).HasMaxLength(50).IsRequired();
        product.Property(p => p.Seller).HasMaxLength(50).IsRequired();
        product.Property(p => p.Image).HasMaxLength(2048).IsRequired();
        product.Property(p => p.Category).HasMaxLength(10).HasConversion<string>(); 
        product.HasMany(p => p.Reviews).WithOne(); 
        product.Property(p => p.UnitPrice).HasColumnType("decimal(8,3)");
        product.Property(p => p.Rating).HasColumnType("int");
        product.Property(p => p.Discount).HasColumnType("int");
        product.HasData(
            new Product("PS5", "Amazon", "imgs/shop/thumbnail-2.jpg", 500, 4, 0, ProductCategory.Vege),
                new Product("Xbox", "Amazon", "imgs/shop/thumbnail-2.jpg", 400, 4, 20, ProductCategory.Snack),
                new Product("Switch", "Amazon", "imgs/shop/thumbnail-2.jpg", 300, 4, 0, ProductCategory.Meats),
                new Product("Dell XPS 15", "Amazon", "imgs/shop/thumbnail-2.jpg", 1500, 4, 50, ProductCategory.Meats)
        ); } 
}