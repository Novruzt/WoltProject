using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wolt.Entities.Entities.WoltEntities;

namespace WOLT.DAL.DATA.FluentAPIs.WoltAPIs
{
    public static class BasketProductQuantityAPI
    {
        public static void Fluent(ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<BasketProductQuantity>();
              
            entity.HasKey(bpq => new { bpq.ProductId, bpq.BasketId });

            entity.HasOne(bpq => bpq.Product)
                  .WithMany()
                  .HasForeignKey(bpq => bpq.ProductId);

            entity.HasOne(bpq => bpq.Basket)
                   .WithMany() 
                  .HasForeignKey(bpq => bpq.BasketId);
        }
    }
}
