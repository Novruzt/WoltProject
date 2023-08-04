using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wolt.Entities.Entities.RestaurantEntities;

namespace WOLT.DAL.DATA.DataSeeds
{
    public static class RestaurantData
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Restaurant>().HasData(
                new Restaurant()
                {
                    Id = 1,
                    BaseAddress="Mehelle 765",
                    CreationTime = DateTime.Now,
                    Description= "Sumgayitin 1nomreli parki",
                    Phone="051 123 00 12",
                    Name="GoyercinPark"
                   
                }
                );

           
        } 
    }
}
