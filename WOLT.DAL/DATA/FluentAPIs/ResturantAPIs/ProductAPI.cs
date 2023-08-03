using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wolt.Entities.Entities.RestaurantEntities;

namespace WOLT.DAL.DATA.FluentAPIs.ResturantAPIs
{
    public static class ProductAPI
    {
        public static void Fluent(ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<Product>();

            entity.Property(e => e.Price).HasColumnType("decimal(12,2)");
        }
    }
}
