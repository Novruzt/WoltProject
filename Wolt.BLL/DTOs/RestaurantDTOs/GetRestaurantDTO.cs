using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wolt.Entities.Entities.RestaurantEntities;
using Wolt.Entities.Entities.UserEntities;

namespace Wolt.BLL.DTOs.RestaurantDTOs
{
    public record GetRestaurantDTO
    {
        public string Name { get; set; }
        public string BaseAddress { get; set; }
        public string Phone { get; set; }
        public string Description { get; set; }
        public ICollection<GetAllDiscountsDTO> Discounts { get; set; }  
        public ICollection<GetUserCommentsForRestaurantDTO> UserComments { get; set; }
    }
}
