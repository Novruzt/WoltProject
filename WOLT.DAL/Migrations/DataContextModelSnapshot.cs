﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WOLT.DAL.DATA;

#nullable disable

namespace WOLT.DAL.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Wolt.Entities.Entities.RestaurantEntities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeleteTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RestaurantId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("RestaurantId");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreationTime = new DateTime(2023, 8, 25, 14, 20, 54, 172, DateTimeKind.Local).AddTicks(9379),
                            IsDeleted = false,
                            Name = "Ickiler",
                            RestaurantId = 1
                        },
                        new
                        {
                            Id = 2,
                            CreationTime = new DateTime(2023, 8, 25, 14, 20, 54, 172, DateTimeKind.Local).AddTicks(9381),
                            IsDeleted = false,
                            Name = "Suplar",
                            RestaurantId = 1
                        });
                });

            modelBuilder.Entity("Wolt.Entities.Entities.RestaurantEntities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("BasketId")
                        .HasColumnType("int");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeleteTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("OrderId")
                        .HasColumnType("int");

                    b.Property<string>("Picture")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(12,2)");

                    b.Property<DateTime?>("UpdateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("BasketId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("OrderId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            CreationTime = new DateTime(2023, 8, 25, 10, 20, 54, 172, DateTimeKind.Utc).AddTicks(9400),
                            Description = "Adi Su",
                            IsDeleted = false,
                            Name = "Su",
                            Price = 0.5m
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 2,
                            CreationTime = new DateTime(2023, 8, 25, 10, 20, 54, 172, DateTimeKind.Utc).AddTicks(9401),
                            Description = "Leziz Sup",
                            IsDeleted = false,
                            Name = "Mercimek",
                            Price = 5m
                        });
                });

            modelBuilder.Entity("Wolt.Entities.Entities.RestaurantEntities.Restaurant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("BaseAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeleteTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Restaurants");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BaseAddress = "Mehelle 765",
                            CreationTime = new DateTime(2023, 8, 25, 14, 20, 54, 172, DateTimeKind.Local).AddTicks(9103),
                            Description = "Sumgayitin 1nomreli parki",
                            IsDeleted = false,
                            Name = "GoyercinPark",
                            Phone = "051 123 00 12"
                        });
                });

            modelBuilder.Entity("Wolt.Entities.Entities.UserEntities.FavoriteFood", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeleteTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("UpdateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("UserId", "ProductId");

                    b.HasIndex("ProductId");

                    b.ToTable("FavoriteFoods");
                });

            modelBuilder.Entity("Wolt.Entities.Entities.UserEntities.FavoriteRestaurant", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("RestaurantId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeleteTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("UpdateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("UserId", "RestaurantId");

                    b.HasIndex("RestaurantId");

                    b.ToTable("FavoriteRestaurants");
                });

            modelBuilder.Entity("Wolt.Entities.Entities.UserEntities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeleteTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProfilePicture")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Token")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdateTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("VerifiedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Wolt.Entities.Entities.UserEntities.UserAddress", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeleteTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UsersAddress");
                });

            modelBuilder.Entity("Wolt.Entities.Entities.UserEntities.UserCard", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CVV")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CardNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeleteTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("ExpireTime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("UpdateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserPayments");
                });

            modelBuilder.Entity("Wolt.Entities.Entities.UserEntities.UserComment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeleteTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Details")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("RestaurantId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RestaurantId");

                    b.HasIndex("UserId");

                    b.ToTable("UserComments");
                });

            modelBuilder.Entity("Wolt.Entities.Entities.UserEntities.UserHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeleteTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("UpdateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserHistories");
                });

            modelBuilder.Entity("Wolt.Entities.Entities.UserEntities.UserOldPassword", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeleteTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("OldPasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OldPasswordSalt")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserOldPasswords");
                });

            modelBuilder.Entity("Wolt.Entities.Entities.UserEntities.UserReview", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeleteTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<decimal>("Score")
                        .HasColumnType("decimal(2,0)");

                    b.Property<DateTime?>("UpdateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("UserId");

                    b.ToTable("UserReviews");
                });

            modelBuilder.Entity("Wolt.Entities.Entities.WoltEntities.Basket", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeleteTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<decimal>("TotalAmount")
                        .HasColumnType("decimal(12,2)");

                    b.Property<DateTime?>("UpdateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Baskets");
                });

            modelBuilder.Entity("Wolt.Entities.Entities.WoltEntities.BasketProductQuantity", b =>
                {
                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("BasketId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeleteTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("ProductId", "BasketId");

                    b.HasIndex("BasketId");

                    b.ToTable("BasketProductQuantities");
                });

            modelBuilder.Entity("Wolt.Entities.Entities.WoltEntities.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeleteTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("OrderStatus")
                        .HasColumnType("int");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("decimal(12,2)");

                    b.Property<DateTime?>("UpdateTime")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UserAddressId")
                        .HasColumnType("int");

                    b.Property<int?>("UserHistoryId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int?>("UserPaymentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserAddressId")
                        .IsUnique()
                        .HasFilter("[UserAddressId] IS NOT NULL");

                    b.HasIndex("UserHistoryId");

                    b.HasIndex("UserId");

                    b.HasIndex("UserPaymentId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Wolt.Entities.Entities.WoltEntities.OrderProductQuantity", b =>
                {
                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeleteTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("ProductId", "OrderId");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderProductQuantities");
                });

            modelBuilder.Entity("Wolt.Entities.Entities.WoltEntities.PromoCode", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeleteTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int?>("OrderId")
                        .HasColumnType("int");

                    b.Property<double>("PromoDiscount")
                        .HasColumnType("float");

                    b.Property<DateTime>("PromoEndTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("PromoName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("PromoStartTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("UpdateTime")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("UserId");

                    b.ToTable("PromoCodes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreationTime = new DateTime(2023, 8, 25, 14, 20, 54, 172, DateTimeKind.Local).AddTicks(9427),
                            IsDeleted = false,
                            PromoDiscount = 10.0,
                            PromoEndTime = new DateTime(2023, 9, 4, 14, 20, 54, 172, DateTimeKind.Local).AddTicks(9428),
                            PromoName = "WelcomeBonus",
                            PromoStartTime = new DateTime(2023, 8, 25, 14, 20, 54, 172, DateTimeKind.Local).AddTicks(9434)
                        },
                        new
                        {
                            Id = 2,
                            CreationTime = new DateTime(2023, 8, 25, 14, 20, 54, 172, DateTimeKind.Local).AddTicks(9477),
                            IsDeleted = false,
                            PromoDiscount = 15.0,
                            PromoEndTime = new DateTime(2023, 9, 4, 14, 20, 54, 172, DateTimeKind.Local).AddTicks(9477),
                            PromoName = "Bonus15",
                            PromoStartTime = new DateTime(2023, 8, 25, 14, 20, 54, 172, DateTimeKind.Local).AddTicks(9479)
                        });
                });

            modelBuilder.Entity("Wolt.Entities.Entities.RestaurantEntities.Category", b =>
                {
                    b.HasOne("Wolt.Entities.Entities.RestaurantEntities.Restaurant", "Restaurant")
                        .WithMany("Categories")
                        .HasForeignKey("RestaurantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Restaurant");
                });

            modelBuilder.Entity("Wolt.Entities.Entities.RestaurantEntities.Product", b =>
                {
                    b.HasOne("Wolt.Entities.Entities.WoltEntities.Basket", null)
                        .WithMany("Products")
                        .HasForeignKey("BasketId");

                    b.HasOne("Wolt.Entities.Entities.RestaurantEntities.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Wolt.Entities.Entities.WoltEntities.Order", null)
                        .WithMany("Products")
                        .HasForeignKey("OrderId");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Wolt.Entities.Entities.UserEntities.FavoriteFood", b =>
                {
                    b.HasOne("Wolt.Entities.Entities.RestaurantEntities.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Wolt.Entities.Entities.UserEntities.User", "User")
                        .WithMany("FavoriteFoods")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Wolt.Entities.Entities.UserEntities.FavoriteRestaurant", b =>
                {
                    b.HasOne("Wolt.Entities.Entities.RestaurantEntities.Restaurant", "Restaurant")
                        .WithMany()
                        .HasForeignKey("RestaurantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Wolt.Entities.Entities.UserEntities.User", "User")
                        .WithMany("FavoriteRestaurants")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Restaurant");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Wolt.Entities.Entities.UserEntities.UserAddress", b =>
                {
                    b.HasOne("Wolt.Entities.Entities.UserEntities.User", "User")
                        .WithMany("UserAddresses")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Wolt.Entities.Entities.UserEntities.UserCard", b =>
                {
                    b.HasOne("Wolt.Entities.Entities.UserEntities.User", "User")
                        .WithMany("UserPayment")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Wolt.Entities.Entities.UserEntities.UserComment", b =>
                {
                    b.HasOne("Wolt.Entities.Entities.RestaurantEntities.Restaurant", "Restaurant")
                        .WithMany("UserComments")
                        .HasForeignKey("RestaurantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Wolt.Entities.Entities.UserEntities.User", "User")
                        .WithMany("UserComments")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Restaurant");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Wolt.Entities.Entities.UserEntities.UserHistory", b =>
                {
                    b.HasOne("Wolt.Entities.Entities.UserEntities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Wolt.Entities.Entities.UserEntities.UserOldPassword", b =>
                {
                    b.HasOne("Wolt.Entities.Entities.UserEntities.User", "User")
                        .WithMany("OldPasswords")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Wolt.Entities.Entities.UserEntities.UserReview", b =>
                {
                    b.HasOne("Wolt.Entities.Entities.RestaurantEntities.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Wolt.Entities.Entities.UserEntities.User", "User")
                        .WithMany("UserReviews")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Wolt.Entities.Entities.WoltEntities.Basket", b =>
                {
                    b.HasOne("Wolt.Entities.Entities.UserEntities.User", "User")
                        .WithMany("Basket")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Wolt.Entities.Entities.WoltEntities.BasketProductQuantity", b =>
                {
                    b.HasOne("Wolt.Entities.Entities.WoltEntities.Basket", "Basket")
                        .WithMany()
                        .HasForeignKey("BasketId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Wolt.Entities.Entities.RestaurantEntities.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Basket");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Wolt.Entities.Entities.WoltEntities.Order", b =>
                {
                    b.HasOne("Wolt.Entities.Entities.UserEntities.UserAddress", "UserAddress")
                        .WithOne()
                        .HasForeignKey("Wolt.Entities.Entities.WoltEntities.Order", "UserAddressId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Wolt.Entities.Entities.UserEntities.UserHistory", null)
                        .WithMany("Orders")
                        .HasForeignKey("UserHistoryId");

                    b.HasOne("Wolt.Entities.Entities.UserEntities.User", "User")
                        .WithMany("Orders")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Wolt.Entities.Entities.UserEntities.UserCard", "UserPayment")
                        .WithMany()
                        .HasForeignKey("UserPaymentId");

                    b.Navigation("User");

                    b.Navigation("UserAddress");

                    b.Navigation("UserPayment");
                });

            modelBuilder.Entity("Wolt.Entities.Entities.WoltEntities.OrderProductQuantity", b =>
                {
                    b.HasOne("Wolt.Entities.Entities.WoltEntities.Order", "Order")
                        .WithMany()
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Wolt.Entities.Entities.RestaurantEntities.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Wolt.Entities.Entities.WoltEntities.PromoCode", b =>
                {
                    b.HasOne("Wolt.Entities.Entities.WoltEntities.Order", null)
                        .WithMany("PromoCodes")
                        .HasForeignKey("OrderId");

                    b.HasOne("Wolt.Entities.Entities.UserEntities.User", null)
                        .WithMany("PromoCodes")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Wolt.Entities.Entities.RestaurantEntities.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("Wolt.Entities.Entities.RestaurantEntities.Restaurant", b =>
                {
                    b.Navigation("Categories");

                    b.Navigation("UserComments");
                });

            modelBuilder.Entity("Wolt.Entities.Entities.UserEntities.User", b =>
                {
                    b.Navigation("Basket");

                    b.Navigation("FavoriteFoods");

                    b.Navigation("FavoriteRestaurants");

                    b.Navigation("OldPasswords");

                    b.Navigation("Orders");

                    b.Navigation("PromoCodes");

                    b.Navigation("UserAddresses");

                    b.Navigation("UserComments");

                    b.Navigation("UserPayment");

                    b.Navigation("UserReviews");
                });

            modelBuilder.Entity("Wolt.Entities.Entities.UserEntities.UserHistory", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("Wolt.Entities.Entities.WoltEntities.Basket", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("Wolt.Entities.Entities.WoltEntities.Order", b =>
                {
                    b.Navigation("Products");

                    b.Navigation("PromoCodes");
                });
#pragma warning restore 612, 618
        }
    }
}
