using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wolt.BLL.DTOs.RestaurantDTOs
{
    public record GetAllDiscountsDTO
    {
        public string DiscountName { get; set; }
        public string Description { get; set; }
        public double Percantage { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
