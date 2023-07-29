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

            OrderAPI.Fluent(modelBuilder);

        }

        public DbSet<Branch> Branches { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<WorkHours> WorkHours { get; set; }
        public DbSet<FavoriteFood> FavoriteFoods { get; set; }
        public DbSet<FavoriteRestaurant> FavoriteRestaurants { get; set; } 
        public DbSet<User> Users { get; set; }
        public DbSet<UserAddress> UsersAddress { get; set; }
        public DbSet<UserComment> UserComments { get; set; }
        public DbSet<UserHistory> UserHistories { get; set; }
        public DbSet<UserPayment> UserPayments { get; set; }
        public DbSet<UserReturn> UserReturns { get; set; }
        public DbSet<UserReview> UserReviews { get; set; }
        public DbSet<Basket>  Baskets { get; set; }
        public DbSet<Courier> Couriers { get; set; }
        public DbSet<Delivery > Deliveries { get; set;}
        public DbSet<Order> Orders { get; set; }
        public DbSet<PromoCode> PromoCodes { get; set; }

    }
}
