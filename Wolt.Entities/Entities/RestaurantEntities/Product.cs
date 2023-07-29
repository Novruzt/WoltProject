using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wolt.Entities.Entities.BaseEntities;

namespace Wolt.Entities.Entities.RestaurantEntities
{
    public class Product:BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string Picture { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        //OrderDetails (many to many)
    }
}
