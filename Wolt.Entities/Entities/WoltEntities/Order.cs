using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wolt.Entities.Entities.BaseEntities;
using Wolt.Entities.Entities.RestaurantEntities;
using Wolt.Entities.Entities.UserEntities;
using Wolt.Entities.Enums;

namespace Wolt.Entities.Entities.WoltEntities
{
    public class Order:BaseEntity
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public DateTime OrderDate { get; set; }
        public double TotalPrice { get; set; }
        public int? UserAddressId { get; set; }
        public UserAddress UserAddress { get; set; }
        public int UserPaymentId { get; set; }
        public UserPayment UserPayment { get; set; }
        public string? Description { get; set; }
        public ICollection<Product> Products { get; set; }
        public ICollection<PromoCode> PromoCodes { get; set; }

    }
}
