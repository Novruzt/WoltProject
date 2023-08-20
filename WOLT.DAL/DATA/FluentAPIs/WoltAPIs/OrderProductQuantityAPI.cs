using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wolt.Entities.Entities.WoltEntities;

namespace WOLT.DAL.DATA.FluentAPIs.WoltAPIs
{
    public static class OrderProductQuantityAPI
    {
        public static void Fluent(ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<OrderProductQuantity>();

            entity.HasKey(bpq => new { bpq.ProductId, bpq.OrderId });

            entity.HasOne(bpq => bpq.Product)
                  .WithMany()
                  .HasForeignKey(bpq => bpq.ProductId);

            entity.HasOne(bpq => bpq.Order)
                   .WithMany()
                  .HasForeignKey(bpq => bpq.OrderId);
        }
    }
}
