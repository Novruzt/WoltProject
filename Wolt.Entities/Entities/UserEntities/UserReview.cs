using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wolt.Entities.Entities.BaseEntities;
using Wolt.Entities.Entities.RestaurantEntities;

namespace Wolt.Entities.Entities.UserEntities
{
    public class UserReview:BaseEntity
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public double Score { get; set; }
        public string Description { get; set; }
        public DateTime ReviewDate { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }

        // Food and FoodId
    }
}
