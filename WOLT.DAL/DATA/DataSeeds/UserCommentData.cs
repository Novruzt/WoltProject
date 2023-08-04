using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wolt.Entities.Entities.UserEntities;

namespace WOLT.DAL.DATA.DataSeeds
{
    public static class UserCommentData
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserComment>().HasData(
                new UserComment()
                {
                    Id = 1,
                    RestaurantId = 1,
                    UserId = 1,
                    CreationTime = DateTime.Now,
                    Details="sadad"
                }
                );

            
        }
    }
}
