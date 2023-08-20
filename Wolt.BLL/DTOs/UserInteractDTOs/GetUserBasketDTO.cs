using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wolt.Entities.Entities.RestaurantEntities;
using Wolt.Entities.Entities.UserEntities;

namespace Wolt.BLL.DTOs.UserInteractDTOs
{
    public record GetUserBasketDTO
    {
        public DateTime CreationTime { get; set; }
        public double TotalAmount { get; set; }
        public List<GetProductsForBasketDTO>? Products { get; set; }
    }
}
