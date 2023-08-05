using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wolt.BLL.DTOs.RestaurantDTOs
{
    public record  GetAllProductsDTO
    {
        public string Name { get; set; }
        public double Price { get; set; }
    }
}
