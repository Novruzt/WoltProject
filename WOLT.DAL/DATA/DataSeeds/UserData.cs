using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wolt.Entities.Entities.UserEntities;

namespace WOLT.DAL.DATA.DataSeeds
{
    public static class UserData
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User()
                {
                    Id = 1,
                    CreationTime = DateTime.Now,
                    Email="asdad@gmaik.com",
                    Password="salam",
                    VerifiedAt = DateTime.Now,
                    Name="Novruz",
                    Phone="12313",
                    Surname="Tarverdiyev",
                    
                }
                );
        }
    }
}
