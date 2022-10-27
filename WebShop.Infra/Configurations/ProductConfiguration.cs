using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using WebShop.Core.Entities;

namespace WebShop.Infra.Configurations; 

internal class ProductConfiguration : IEntityTypeConfiguration<Product> 
{ 
    public void Configure(EntityTypeBuilder<Product> product) 
    {
        product.HasKey(p => p.Id); 
        product.Property(p => p.Name).HasMaxLength(50).IsRequired();
        product.Property(p => p.Seller).HasMaxLength(50).IsRequired();
        product.Property(p => p.Image).HasMaxLength(2048).IsRequired();
        product.Property(p => p.Category).HasMaxLength(10).HasConversion<string>(); 
        product.HasMany(p => p.Reviews).WithOne(r=>r.Product).OnDelete(DeleteBehavior.Cascade); 
        product.Property(p => p.UnitPrice).HasColumnType("decimal(8,3)");
        product.Property(p => p.Rating).HasColumnType("int");
        product.Property(p => p.Discount).HasColumnType("int");



        product.HasData(
            new Product(1, "PS5", "Amazon", "imgs/shop/thumbnail-2.jpg", 500M, 4, 0, ProductCategory.Vege),
                new Product(2, "Xbox", "Amazon", "imgs/shop/thumbnail-2.jpg", 400M, 4, 20, ProductCategory.Snack),
                new Product(3, "Switch", "Amazon", "imgs/shop/thumbnail-2.jpg", 300M, 4, 0, ProductCategory.Meats),
                new Product(4, "Dell XPS 15", "Amazon", "imgs/shop/thumbnail-2.jpg", 1500M, 4, 50, ProductCategory.Meats)
        ); } 
}