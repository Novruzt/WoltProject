using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wolt.Entities.Entities.BaseEntities;

namespace Wolt.Entities.Entities.RestaurantEntities
{
    public class Discount:BaseEntity
    {
        public int RestaurantId { get; set; }
        public Restaurant Restaurant { get; set; }
        public string DiscountName { get; set; }
        public string Description { get; set; }
        public double Percantage { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
