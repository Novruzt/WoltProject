using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Wolt.Entities;
using Wolt.Entities.Entities;
using Wolt.Entities.Entities.BaseEntities;
using Wolt.Entities.Entities.RestaurantEntities;
using Wolt.Entities.Entities.UserEntities;
using Wolt.Entities.Entities.WoltEntities;
using WOLT.DAL.DATA.DataSeeds;
using WOLT.DAL.DATA.FluentAPIs.ResturantAPIs;
using WOLT.DAL.DATA.FluentAPIs.UserAPIs;
using WOLT.DAL.DATA.FluentAPIs.WoltAPIs;
using WOLT.DAL.DATA.ForBaseEntity;

namespace WOLT.DAL.DATA
{
    public class DataContext :DbContext
    {
        public DataContext(DbContextOptions<DataContext> options):base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.IgnoreDeleted();
            modelBuilder.ActiveOrders(); //Global Query Filter for only Active/Waiting Orders

            
            
            ProductAPI.Fluent(modelBuilder);
            UserReviewAPI.Fluent(modelBuilder);
            BasketAPI.Fluent(modelBuilder);
            OrderAPI.Fluent(modelBuilder);
            FavoriteEntityAPI.Fluent(modelBuilder);
            BasketProductQuantityAPI.Fluent(modelBuilder);
            OrderProductQuantityAPI.Fluent(modelBuilder);

           
            RestaurantData.Seed(modelBuilder);
            CategoryData.Seed(modelBuilder);
            ProductData.Seed(modelBuilder);
            PromoCodeData.Seed(modelBuilder);
 
        }

        #region intSaveChanges()
        /*
       public override int SaveChanges()
            {
                foreach (var entry in ChangeTracker.Entries<BaseEntity>())
                {
                    if (entry.State == EntityState.Deleted)
                    {
                        if (entry.Entity is Basket)
                        {
                            entry.State = EntityState.Deleted;
                        }

                        else if(entry.Entity is FavoriteFood)
                        {
                            entry.State = EntityState.Deleted;
                        }

                        else if(entry.Entity is FavoriteRestaurant)
                        {
                            entry.State = EntityState.Deleted;
                        }
                        else
                        {
                            entry.State = EntityState.Modified;
                            entry.Entity.DeleteTime = DateTime.Now;
                            entry.Entity.IsDeleted = true;

                            if (entry.Entity.IsDeleted == false && entry.OriginalValues["IsDeleted"] as bool? == true)
                            {
                                entry.Entity.UpdateTime = null;
                                entry.Entity.CreationTime = DateTime.Now;
                                entry.Entity.DeleteTime = null;
                            }
                        }
                    }
                    else
                    {
                    
                        _ = entry.State switch
                        {
                            EntityState.Added => entry.Entity.CreationTime = DateTime.Now,
                            EntityState.Modified => entry.Entity.UpdateTime = DateTime.Now,
                            _ => DateTime.Now
                        };

                        if (entry.State == EntityState.Modified)
                        {
                            if (entry.Entity.IsDeleted == false && entry.OriginalValues["IsDeleted"] as bool? == true)
                            {
                                entry.Entity.UpdateTime = null;
                                entry.Entity.CreationTime = DateTime.Now;
                                entry.Entity.DeleteTime = null;
                            }
                        }
                    }
                }

                foreach (var entry in ChangeTracker.Entries<Order>())
                {
                    if (entry.State == EntityState.Added)
                        entry.Entity.OrderStatus = 0;
                }

                return base.SaveChanges();
            }
        */
        #endregion
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<BaseEntity>())
            {
                if (entry.State == EntityState.Deleted)
                {
                    if (entry.Entity is Basket)
                    {
                        entry.State = EntityState.Deleted;
                    }

                    else if (entry.Entity is FavoriteFood)
                    {
                        entry.State = EntityState.Deleted;
                    }

                    else if (entry.Entity is FavoriteRestaurant)
                    {
                        entry.State = EntityState.Deleted;
                    }
                    else
                    {
                        entry.State = EntityState.Modified;
                        entry.Entity.DeleteTime = DateTime.Now;
                        entry.Entity.IsDeleted = true;

                        if (entry.Entity.IsDeleted == false && entry.OriginalValues["IsDeleted"] as bool? == true)
                        {
                            entry.Entity.UpdateTime = null;
                            entry.Entity.CreationTime = DateTime.Now;
                            entry.Entity.DeleteTime = null;
                        }
                    }
                }
                else
                {

                    _ = entry.State switch
                    {
                        EntityState.Added => entry.Entity.CreationTime = DateTime.Now,
                        EntityState.Modified => entry.Entity.UpdateTime = DateTime.Now,
                        _ => DateTime.Now
                    };

                    if (entry.State == EntityState.Modified)
                    {
                        if (entry.Entity.IsDeleted == false && entry.OriginalValues["IsDeleted"] as bool? == true)
                        {
                            entry.Entity.UpdateTime = null;
                            entry.Entity.CreationTime = DateTime.Now;
                            entry.Entity.DeleteTime = null;
                        }
                    }
                }
            }

            foreach (var entry in ChangeTracker.Entries<Order>())
            {
                if (entry.State == EntityState.Added)
                    entry.Entity.OrderStatus = 0;
            }


            return base.SaveChangesAsync(cancellationToken);
        }


        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<FavoriteFood> FavoriteFoods { get; set; }
        public DbSet<FavoriteRestaurant> FavoriteRestaurants { get; set; } 
        public DbSet<User> Users { get; set; }
        public DbSet<UserAddress> UsersAddress { get; set; }
        public DbSet<UserComment> UserComments { get; set; }
        public DbSet<UserHistory> UserHistories { get; set; }
        public DbSet<UserCard> UserPayments { get; set; }
        public DbSet<UserReview> UserReviews { get; set; }
        public DbSet<Basket>  Baskets { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<PromoCode> PromoCodes { get; set; }
        public DbSet<UserOldPassword> UserOldPasswords { get; set; }
        public DbSet<BasketProductQuantity> BasketProductQuantities { get; set; }
        public DbSet<OrderProductQuantity> OrderProductQuantities { get; set;}

    }
}
