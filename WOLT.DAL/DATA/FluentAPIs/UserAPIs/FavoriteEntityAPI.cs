using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wolt.Entities.Entities.UserEntities;

namespace WOLT.DAL.DATA.FluentAPIs.UserAPIs
{
    public static class FavoriteEntityAPI
    {
        public static void Fluent(ModelBuilder modelBuilder)
        {
            var restaurant = modelBuilder.Entity<FavoriteRestaurant>();

            restaurant.HasKey(fr => new { fr.UserId, fr.RestaurantId });

            restaurant.HasOne(fr => fr.User)
                  .WithMany(u => u.FavoriteRestaurants)
                  .HasForeignKey(fr => fr.UserId);

           restaurant.HasOne(fr => fr.Restaurant)
               .WithMany()
               .HasForeignKey(fr => fr.RestaurantId);


            var product = modelBuilder.Entity<FavoriteFood>();

            product.HasKey(ff => new { ff.UserId, ff.ProductId });

            product.HasOne(ff => ff.User)
                  .WithMany(u => u.FavoriteFoods)
                 .HasForeignKey(ff => ff.UserId);

            product.HasOne(ff => ff.Product)
                   .WithMany() 
                   .HasForeignKey(ff => ff.ProductId);



        }
    }
}
