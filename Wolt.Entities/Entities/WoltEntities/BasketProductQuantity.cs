using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wolt.Entities.Entities.BaseEntities;
using Wolt.Entities.Entities.RestaurantEntities;

namespace Wolt.Entities.Entities.WoltEntities
{
    public class BasketProductQuantity:BaseEntity
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int BasketId { get; set; }
        public Basket Basket { get; set; }
        public int Quantity { get; set; }
    }
}
