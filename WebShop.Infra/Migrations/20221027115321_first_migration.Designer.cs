﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebShop.Infra;

#nullable disable

namespace WebShop.Infra.Migrations
{
    [DbContext(typeof(WebShopDbContext))]
    [Migration("20221027115321_first_migration")]
    partial class first_migration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("WebShop.Core.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("Discount")
                        .HasColumnType("int");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasMaxLength(2048)
                        .HasColumnType("nvarchar(2048)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.Property<string>("Seller")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("decimal(8,3)");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Category = "Vege",
                            CreatedAt = new DateTime(2022, 10, 27, 13, 53, 21, 240, DateTimeKind.Local).AddTicks(4351),
                            Discount = 0,
                            Image = "imgs/shop/thumbnail-2.jpg",
                            Name = "PS5",
                            Rating = 4,
                            Seller = "Amazon",
                            UnitPrice = 0m
                        },
                        new
                        {
                            Id = 2,
                            Category = "Snack",
                            CreatedAt = new DateTime(2022, 10, 27, 13, 53, 21, 240, DateTimeKind.Local).AddTicks(4391),
                            Discount = 20,
                            Image = "imgs/shop/thumbnail-2.jpg",
                            Name = "Xbox",
                            Rating = 4,
                            Seller = "Amazon",
                            UnitPrice = 0m
                        },
                        new
                        {
                            Id = 3,
                            Category = "Meats",
                            CreatedAt = new DateTime(2022, 10, 27, 13, 53, 21, 240, DateTimeKind.Local).AddTicks(4395),
                            Discount = 0,
                            Image = "imgs/shop/thumbnail-2.jpg",
                            Name = "Switch",
                            Rating = 4,
                            Seller = "Amazon",
                            UnitPrice = 0m
                        },
                        new
                        {
                            Id = 4,
                            Category = "Meats",
                            CreatedAt = new DateTime(2022, 10, 27, 13, 53, 21, 240, DateTimeKind.Local).AddTicks(4398),
                            Discount = 50,
                            Image = "imgs/shop/thumbnail-2.jpg",
                            Name = "Dell XPS 15",
                            Rating = 4,
                            Seller = "Amazon",
                            UnitPrice = 0m
                        });
                });

            modelBuilder.Entity("WebShop.Core.Entities.Review", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Score")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("User")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("Review");
                });

            modelBuilder.Entity("WebShop.Core.Entities.Review", b =>
                {
                    b.HasOne("WebShop.Core.Entities.Product", "Product")
                        .WithMany("Reviews")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("WebShop.Core.Entities.Product", b =>
                {
                    b.Navigation("Reviews");
                });
#pragma warning restore 612, 618
        }
    }
}
