﻿// <auto-generated />
using System;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Data.Migrations
{
    [DbContext(typeof(CoffeeShopDbContext))]
    [Migration("20231212111431_CoffeeCupCakeManyToOne")]
    partial class CoffeeCupCakeManyToOne
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Models.CoffeeCupIngredient", b =>
                {
                    b.Property<Guid>("CoffeeCupId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IngredientId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("CoffeeCupId", "IngredientId");

                    b.HasIndex("IngredientId");

                    b.ToTable("CoffeeCupIngredients");
                });

            modelBuilder.Entity("Models.CoffeeCupStore", b =>
                {
                    b.Property<Guid>("CoffeeCupId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("StoreId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CoffeeCupStoreCoffeeCupId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CoffeeCupStoreStoreId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("CoffeeCupId", "StoreId");

                    b.HasIndex("StoreId");

                    b.HasIndex("CoffeeCupStoreCoffeeCupId", "CoffeeCupStoreStoreId");

                    b.ToTable("CoffeeCupStores");
                });

            modelBuilder.Entity("Models.Customer", b =>
                {
                    b.Property<Guid>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CustomerId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("Models.Ingredient", b =>
                {
                    b.Property<Guid>("IngredientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("MeasurementUnit")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("IngredientId");

                    b.ToTable("Ingredients");
                });

            modelBuilder.Entity("Models.Item", b =>
                {
                    b.Property<Guid>("ItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ItemType")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid>("StoreId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ItemId");

                    b.HasIndex("StoreId");

                    b.ToTable("Items");

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("Models.Order", b =>
                {
                    b.Property<Guid>("OrderID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CustomerID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsAccepted")
                        .HasColumnType("bit");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("StoreID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("TotalAmount")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("OrderID");

                    b.HasIndex("CustomerID");

                    b.HasIndex("StoreID");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Models.OrderDetail", b =>
                {
                    b.Property<Guid>("OrderDetailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ItemId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("OrderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<decimal>("Subtotal")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("OrderDetailId");

                    b.HasIndex("ItemId");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderDetails");
                });

            modelBuilder.Entity("Models.Post", b =>
                {
                    b.Property<Guid>("PostId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CustomerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ItemId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PostId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("ItemId");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("Models.Store", b =>
                {
                    b.Property<Guid>("StoreId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BrandId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StoreId");

                    b.ToTable("Stores");
                });

            modelBuilder.Entity("Models.Cake", b =>
                {
                    b.HasBaseType("Models.Item");

                    b.Property<Guid>("CoffeeCupId")
                        .HasColumnType("uniqueidentifier");

                    b.HasIndex("CoffeeCupId");

                    b.ToTable("Cakes");
                });

            modelBuilder.Entity("Models.CoffeeBean", b =>
                {
                    b.HasBaseType("Models.Item");

                    b.Property<string>("Origin")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoastLevel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("CoffeeBeans");
                });

            modelBuilder.Entity("Models.CoffeeCup", b =>
                {
                    b.HasBaseType("Models.Item");

                    b.Property<Guid>("CustomerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Size")
                        .HasColumnType("int");

                    b.ToTable("CoffeeCups");
                });

            modelBuilder.Entity("Models.CoffeeCupIngredient", b =>
                {
                    b.HasOne("Models.CoffeeCup", "CoffeeCup")
                        .WithMany("CoffeeCupIngredients")
                        .HasForeignKey("CoffeeCupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Models.Ingredient", "Ingredient")
                        .WithMany("CoffeeCupIngredients")
                        .HasForeignKey("IngredientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CoffeeCup");

                    b.Navigation("Ingredient");
                });

            modelBuilder.Entity("Models.CoffeeCupStore", b =>
                {
                    b.HasOne("Models.CoffeeCup", "CoffeeCup")
                        .WithMany("CoffeeCupStores")
                        .HasForeignKey("CoffeeCupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Models.Store", "Store")
                        .WithMany("CoffeeCupStores")
                        .HasForeignKey("StoreId")
                        .IsRequired();

                    b.HasOne("Models.CoffeeCupStore", null)
                        .WithMany("CoffeeCupStores")
                        .HasForeignKey("CoffeeCupStoreCoffeeCupId", "CoffeeCupStoreStoreId");

                    b.Navigation("CoffeeCup");

                    b.Navigation("Store");
                });

            modelBuilder.Entity("Models.Item", b =>
                {
                    b.HasOne("Models.Store", "Store")
                        .WithMany()
                        .HasForeignKey("StoreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Store");
                });

            modelBuilder.Entity("Models.Order", b =>
                {
                    b.HasOne("Models.Customer", "Customer")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Models.Store", "Store")
                        .WithMany("Orders")
                        .HasForeignKey("StoreID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Store");
                });

            modelBuilder.Entity("Models.OrderDetail", b =>
                {
                    b.HasOne("Models.Item", "Item")
                        .WithMany()
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Models.Order", "Order")
                        .WithMany("OrderDetails")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Item");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("Models.Post", b =>
                {
                    b.HasOne("Models.Customer", "Customer")
                        .WithMany("Posts")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Models.Item", "Item")
                        .WithMany()
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Item");
                });

            modelBuilder.Entity("Models.Cake", b =>
                {
                    b.HasOne("Models.CoffeeCup", "CoffeeCup")
                        .WithMany("Cakes")
                        .HasForeignKey("CoffeeCupId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Models.Item", null)
                        .WithOne()
                        .HasForeignKey("Models.Cake", "ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CoffeeCup");
                });

            modelBuilder.Entity("Models.CoffeeBean", b =>
                {
                    b.HasOne("Models.Item", null)
                        .WithOne()
                        .HasForeignKey("Models.CoffeeBean", "ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Models.CoffeeCup", b =>
                {
                    b.HasOne("Models.Item", null)
                        .WithOne()
                        .HasForeignKey("Models.CoffeeCup", "ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Models.CoffeeCupStore", b =>
                {
                    b.Navigation("CoffeeCupStores");
                });

            modelBuilder.Entity("Models.Customer", b =>
                {
                    b.Navigation("Orders");

                    b.Navigation("Posts");
                });

            modelBuilder.Entity("Models.Ingredient", b =>
                {
                    b.Navigation("CoffeeCupIngredients");
                });

            modelBuilder.Entity("Models.Order", b =>
                {
                    b.Navigation("OrderDetails");
                });

            modelBuilder.Entity("Models.Store", b =>
                {
                    b.Navigation("CoffeeCupStores");

                    b.Navigation("Orders");
                });

            modelBuilder.Entity("Models.CoffeeCup", b =>
                {
                    b.Navigation("Cakes");

                    b.Navigation("CoffeeCupIngredients");

                    b.Navigation("CoffeeCupStores");
                });
#pragma warning restore 612, 618
        }
    }
}
