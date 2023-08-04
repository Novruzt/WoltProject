using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wolt.BLL.DTOs.RestaurantDTOs
{
    public record WorkHoursDTO
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string DayofWeek { get; set; }
    }
}
