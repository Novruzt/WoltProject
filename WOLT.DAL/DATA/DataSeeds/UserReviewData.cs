using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wolt.Entities.Entities.UserEntities;

namespace WOLT.DAL.DATA.DataSeeds
{
    public static class UserReviewData
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserReview>().HasData(
                new UserReview()
                {
                    Id = 1,
                    ProductId = 1,
                    UserId = 1,
                    Description = "Test",
                    CreationTime = DateTime.Now,
                    Score = 9,
                   

                },
                new UserReview()
                {
                    Id=2,
                    ProductId = 1,
                    UserId = 1,
                    Description = "Test2",
                    CreationTime = DateTime.Now,
                    Score = 1,

                },
                new UserReview()
                {
                    Id=3,
                    ProductId = 2,
                    UserId = 1,
                    Description= "Test3",
                    CreationTime= DateTime.Now,
                    Score = 10,
                }


                ); ;
        }
    }
}
