using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wolt.Entities.Entities.BaseEntities;

namespace Wolt.Entities.Entities.RestaurantEntities
{
    public class Branch:BaseEntity
    {
        public int RestaurantId { get; set; }
        public Restaurant Restaurant { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public int WorkHourdsId { get; set; }
        public ICollection<WorkHours> WorkHours { get; set; }
    }
}
