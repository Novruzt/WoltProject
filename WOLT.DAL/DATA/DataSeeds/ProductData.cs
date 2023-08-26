using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wolt.Entities.Entities.RestaurantEntities;

namespace WOLT.DAL.DATA.DataSeeds
{
    public  static class ProductData
    {
        public static void Seed(ModelBuilder modelbuilder)
        {
            modelbuilder.Entity<Product>().HasData(
                new Product()
                {
                    Id = 1,
                    CategoryId = 1,
                    CreationTime = DateTime.UtcNow,
                    Description = "Adi Su",
                    Price = 0.5,
                    Name = "Su",
                    Picture= "file:///C://Users//User//Desktop//WoltPics//arı-su.jpg"

                },
                new Product()
                {
                    Id= 2,
                    CategoryId = 2,
                    CreationTime = DateTime.UtcNow,
                    Price= 5,
                    Description="Leziz Sup",
                    Name="Mercimek",
                    Picture= "file:///C://Users//User//Desktop//WoltPics//indir.jpg"

                }
                );

            

        }
    }
}
