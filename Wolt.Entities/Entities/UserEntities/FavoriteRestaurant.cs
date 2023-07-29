using System;
using Wolt.Entities.Entities.BaseEntities;
using Wolt.Entities.Entities.RestaurantEntities;

namespace Wolt.Entities.Entities.UserEntities
{
    public class FavoriteRestaurant: BaseEntity
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public ICollection<Restaurant> Restaurants { get; set; }

        //reliationsip here:
        
        // Restaurant 
    }
}
