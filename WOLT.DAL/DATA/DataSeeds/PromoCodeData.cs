using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wolt.Entities.Entities.RestaurantEntities;
using Wolt.Entities.Entities.WoltEntities;

namespace WOLT.DAL.DATA.DataSeeds
{
    public static class PromoCodeData
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PromoCode>().HasData(
                new PromoCode()
                {
                    Id = 1,
                    CreationTime = DateTime.Now,
                    PromoEndTime = DateTime.Now.AddDays(10),
                    PromoStartTime = DateTime.Now,
                    PromoDiscount = 10,
                    PromoName="WelcomeBonus"
                    
                },

                new PromoCode()
                {
                    Id = 2,
                    CreationTime = DateTime.Now,
                    PromoEndTime = DateTime.Now.AddDays(10),
                    PromoStartTime = DateTime.Now,
                    PromoDiscount = 15,
                    PromoName = "Bonus15"
                }
                );
        }
    }
}
