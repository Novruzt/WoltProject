using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wolt.Entities.Entities.WoltEntities;

namespace WOLT.DAL.DATA.FluentAPIs.WoltAPIs
{
    public static  class PromoCodeAPİ
    {
        public static void Fluent(ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<PromoCode>();

            entity
               .Property(e => e.PromoDiscount).HasColumnType("decimal(5,3)");

        }
    }
}
