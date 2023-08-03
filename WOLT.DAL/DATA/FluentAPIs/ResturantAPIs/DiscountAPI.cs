using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wolt.Entities.Entities.RestaurantEntities;

namespace WOLT.DAL.DATA.FluentAPIs.ResturantAPIs
{
    public static class DiscountAPI
    {
        public static void Fluent(ModelBuilder modelBuilder) 
        {
            var entity = modelBuilder.Entity<Discount>();

            entity.Property(e => e.Percantage).HasColumnType("decimal(5,2)");
        }
    }
}
