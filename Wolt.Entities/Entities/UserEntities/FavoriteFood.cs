using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wolt.Entities.Entities.BaseEntities;
using Wolt.Entities.Entities.RestaurantEntities;

namespace Wolt.Entities.Entities.UserEntities
{
    public class FavoriteFood:BaseEntity
    {
        public int UserId { get; set; }
        public User User { get; set; } 
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
