﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Task.Persistence.Data;

#nullable disable

namespace Task.Persistence.Migrations
{
    [DbContext(typeof(TaskContext))]
    [Migration("20240705024216_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Task.Domain.Entities.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Image")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Items");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Image = "Images\\Items\\1.jpg",
                            Name = "Incredible Granite Soap"
                        },
                        new
                        {
                            Id = 2,
                            Image = "Images\\Items\\2.jpg",
                            Name = "Small Frozen Towels"
                        },
                        new
                        {
                            Id = 3,
                            Image = "Images\\Items\\3.jpg",
                            Name = "Incredible Steel Chips"
                        },
                        new
                        {
                            Id = 4,
                            Image = "Images\\Items\\4.jpg",
                            Name = "Incredible Cotton Chicken"
                        },
                        new
                        {
                            Id = 5,
                            Image = "Images\\Items\\5.jpg",
                            Name = "Small Plastic Car"
                        },
                        new
                        {
                            Id = 6,
                            Image = "Images\\Items\\6.jpg",
                            Name = "Awesome Rubber Pizza"
                        },
                        new
                        {
                            Id = 7,
                            Image = "Images\\Items\\7.jpg",
                            Name = "Generic Granite Gloves"
                        },
                        new
                        {
                            Id = 8,
                            Image = "Images\\Items\\8.jpg",
                            Name = "Gorgeous Soft Cheese"
                        },
                        new
                        {
                            Id = 9,
                            Image = "Images\\Items\\9.jpg",
                            Name = "Sleek Cotton Bike"
                        },
                        new
                        {
                            Id = 10,
                            Image = "Images\\Items\\10.jpg",
                            Name = "Small Metal Mouse"
                        });
                });

            modelBuilder.Entity("Task.Domain.Entities.Store", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Image")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Stores");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Image = "Images\\Stores\\1.jpg",
                            Name = "Kovacek LLC"
                        },
                        new
                        {
                            Id = 2,
                            Image = "Images\\Stores\\2.jpg",
                            Name = "VonRueden LLC"
                        },
                        new
                        {
                            Id = 3,
                            Image = "Images\\Stores\\3.jpg",
                            Name = "Bechtelar Group"
                        },
                        new
                        {
                            Id = 4,
                            Image = "Images\\Stores\\4.jpg",
                            Name = "Johns LLC"
                        },
                        new
                        {
                            Id = 5,
                            Image = "Images\\Stores\\5.jpg",
                            Name = "Heller Inc"
                        },
                        new
                        {
                            Id = 6,
                            Image = "Images\\Stores\\6.jpg",
                            Name = "Marquardt - Steuber"
                        },
                        new
                        {
                            Id = 7,
                            Image = "Images\\Stores\\7.jpg",
                            Name = "Kub - Gutmann"
                        },
                        new
                        {
                            Id = 8,
                            Image = "Images\\Stores\\8.jpg",
                            Name = "Roob Group"
                        },
                        new
                        {
                            Id = 9,
                            Image = "Images\\Stores\\9.jpg",
                            Name = "Kerluke - Erdman"
                        },
                        new
                        {
                            Id = 10,
                            Image = "Images\\Stores\\10.jpg",
                            Name = "Nitzsche Inc"
                        });
                });

            modelBuilder.Entity("Task.Domain.Entities.StoreItem", b =>
                {
                    b.Property<int>("ItemId")
                        .HasColumnType("int");

                    b.Property<int>("StoreId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("ItemId", "StoreId");

                    b.HasIndex("StoreId");

                    b.ToTable("StoreItems");

                    b.HasData(
                        new
                        {
                            ItemId = 5,
                            StoreId = 4,
                            Quantity = 60
                        },
                        new
                        {
                            ItemId = 10,
                            StoreId = 1,
                            Quantity = 56
                        },
                        new
                        {
                            ItemId = 1,
                            StoreId = 4,
                            Quantity = 100
                        },
                        new
                        {
                            ItemId = 4,
                            StoreId = 1,
                            Quantity = 5
                        },
                        new
                        {
                            ItemId = 6,
                            StoreId = 6,
                            Quantity = 86
                        },
                        new
                        {
                            ItemId = 5,
                            StoreId = 6,
                            Quantity = 31
                        },
                        new
                        {
                            ItemId = 8,
                            StoreId = 3,
                            Quantity = 77
                        },
                        new
                        {
                            ItemId = 7,
                            StoreId = 1,
                            Quantity = 20
                        },
                        new
                        {
                            ItemId = 6,
                            StoreId = 8,
                            Quantity = 16
                        },
                        new
                        {
                            ItemId = 2,
                            StoreId = 5,
                            Quantity = 7
                        },
                        new
                        {
                            ItemId = 3,
                            StoreId = 10,
                            Quantity = 93
                        },
                        new
                        {
                            ItemId = 5,
                            StoreId = 5,
                            Quantity = 83
                        },
                        new
                        {
                            ItemId = 1,
                            StoreId = 1,
                            Quantity = 54
                        },
                        new
                        {
                            ItemId = 7,
                            StoreId = 3,
                            Quantity = 9
                        },
                        new
                        {
                            ItemId = 9,
                            StoreId = 6,
                            Quantity = 99
                        },
                        new
                        {
                            ItemId = 3,
                            StoreId = 5,
                            Quantity = 76
                        },
                        new
                        {
                            ItemId = 6,
                            StoreId = 9,
                            Quantity = 49
                        });
                });

            modelBuilder.Entity("Task.Domain.Entities.StoreItem", b =>
                {
                    b.HasOne("Task.Domain.Entities.Item", "Item")
                        .WithMany()
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Task.Domain.Entities.Store", "store")
                        .WithMany()
                        .HasForeignKey("StoreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Item");

                    b.Navigation("store");
                });
#pragma warning restore 612, 618
        }
    }
}
