using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wolt.Entities.Entities.RestaurantEntities;
using Wolt.Entities.Entities.UserEntities;

namespace WOLT.DAL.DATA.FluentAPIs.UserAPIs
{
    public static class UserReviewAPI
    {
        public static void Fluent(ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<UserReview>();

            entity.Property(e => e.Score).HasColumnType("decimal(2,0)");
        }
    }
}
