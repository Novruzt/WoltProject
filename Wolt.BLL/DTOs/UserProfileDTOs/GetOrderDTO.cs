using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wolt.Entities.Entities.RestaurantEntities;
using Wolt.Entities.Entities.UserEntities;
using Wolt.Entities.Entities.WoltEntities;
using Wolt.Entities.Enums;

namespace Wolt.BLL.DTOs.UserProfileDTOs
{
    public record GetOrderDTO
    {
        public GetOrderDTO()
        {
            Products=new List<GetOrderProductsDTO>();
        }
        public string OrderStatus { get; set; }
        public DateTime OrderDate { get; set; }
        public double TotalPrice { get; set; }
        public string UserLocation { get; set; }
        public List<GetOrderProductsDTO>? Products { get; set; }
    }
}
