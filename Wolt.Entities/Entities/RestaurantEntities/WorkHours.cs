using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wolt.Entities.Entities.BaseEntities;

namespace Wolt.Entities.Entities.RestaurantEntities
{
    public class WorkHours:BaseEntity
    {
        public int BracnhId { get; set; }
        public Branch Branch { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string DayofWeek { get; set; }
    }
}
