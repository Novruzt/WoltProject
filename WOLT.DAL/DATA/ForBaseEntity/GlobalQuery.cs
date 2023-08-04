using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wolt.Entities.Entities.WoltEntities;
using Wolt.Entities.Enums;

namespace WOLT.DAL.DATA.ForBaseEntity
{
    public static class GlobalQuery
    {
        public static void ActiveOrders(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>().HasQueryFilter(o => o.OrderStatus == OrderStatus.Accepted || o.OrderStatus == OrderStatus.Waiting);
        }
    }
}
