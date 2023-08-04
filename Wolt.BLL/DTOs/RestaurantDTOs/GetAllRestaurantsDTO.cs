using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wolt.BLL.DTOs.RestaurantDTOs
{
    public record GetAllRestaurantsDTO
    {
        public string Name { get; set; }
        public string BaseAddress { get; set; }
        public string Phone { get; set; }
        public string Description { get; set; }
      
    }
}
