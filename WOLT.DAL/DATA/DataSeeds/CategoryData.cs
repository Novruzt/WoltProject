using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wolt.Entities.Entities.RestaurantEntities;

namespace WOLT.DAL.DATA.DataSeeds
{
    public static class CategoryData
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category()
                {
                    Id = 1,
                    CreationTime = DateTime.Now,
                    Name = "Ickiler",
                    RestaurantId = 1,
                },

                new Category()
                {
                    Id=2,
                    CreationTime = DateTime.Now,
                    Name="Suplar",
                    RestaurantId = 1,
                }
                );
        }
    }
}
