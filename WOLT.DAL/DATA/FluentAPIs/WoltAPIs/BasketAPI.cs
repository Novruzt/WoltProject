using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wolt.Entities.Entities.RestaurantEntities;
using Wolt.Entities.Entities.WoltEntities;

namespace WOLT.DAL.DATA.FluentAPIs.WoltAPIs
{
    public static class BasketAPI
    {
        public static void Fluent(ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<Basket>();

            entity.Property(e => e.TotalAmount).HasColumnType("decimal(12,2)");
        }
    }
}
