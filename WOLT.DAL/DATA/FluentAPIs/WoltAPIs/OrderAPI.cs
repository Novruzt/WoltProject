using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wolt.Entities.Entities;
using Wolt.Entities.Entities.WoltEntities;

namespace WOLT.DAL.DATA.FluentAPIs.WoltAPIs
{
    public static class OrderAPI
    {
        public static void Fluent(ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<Order>();

            entity
            .HasOne(o => o.UserAddress)
            .WithOne() 
            .HasForeignKey<Order>(o => o.UserAddressId)
            .OnDelete(DeleteBehavior.Restrict);

            entity
             .HasOne(o => o.User)
             .WithMany(u => u.Orders)
             .HasForeignKey(o => o.UserId)
             .OnDelete(DeleteBehavior.NoAction);


        }
    }
}
