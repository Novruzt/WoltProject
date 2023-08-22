using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wolt.Entities.Entities.BaseEntities;
using Wolt.Entities.Entities.RestaurantEntities;
using Wolt.Entities.Entities.WoltEntities;

namespace Wolt.Entities.Entities.UserEntities
{
    public class User :BaseEntity
    {
        //User properties:
        public string Name { get; set; }
        public string Surname { get; set; }
        public string? ProfilePicture { get; set; }
        public string Phone { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public string PasswordSalt { get; set; }
        public string PasswordHash { get; set; }
        public string? Token  { get; set; }
        public DateTime? VerifiedAt { get; set; }
        public ICollection<UserOldPassword>? OldPasswords { get; set; }
        public ICollection<FavoriteFood>? FavoriteFoods { get; set; }
        public ICollection<FavoriteRestaurant>? FavoriteRestaurants { get; set; }
        public ICollection<PromoCode>? PromoCodes { get; set; }
        public ICollection<UserCard>? UserPayment { get; set; }
        public ICollection<Order>? Orders { get; set; }
        public ICollection<Basket>? Basket { get; set; }
        public ICollection<UserAddress>? UserAddresses { get; set; }
        public ICollection<UserReview>? UserReviews { get; set; } 
        public ICollection<UserComment>? UserComments { get; set; }

    }
}
