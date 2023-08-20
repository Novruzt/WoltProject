using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wolt.Entities.Entities.BaseEntities;
using Wolt.Entities.Entities.RestaurantEntities;
using Wolt.Entities.Entities.UserEntities;

namespace Wolt.Entities.Entities.WoltEntities
{
    public class Basket:BaseEntity
    {
        public Basket()
        {
            Products = new List<Product>();
        }
        public int UserId { get; set; }
        public User User { get; set; }
        public DateTime CreationTime { get; set; }    
        public double TotalAmount { get; set; }
        public ICollection<Product>? Products { get; set; } 

    }
}
