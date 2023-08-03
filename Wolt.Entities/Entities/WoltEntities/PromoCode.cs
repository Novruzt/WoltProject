using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wolt.Entities.Entities.BaseEntities;
using Wolt.Entities.Entities.UserEntities;

namespace Wolt.Entities.Entities.WoltEntities
{
    public class PromoCode :BaseEntity
    {
        public string PromoName { get; set; } 
        public DateTime PromoStartTime { get; set; }
        public DateTime PromoEndTime { get; set;}
        public double PromoDisCount { get; set; }
    }
}
