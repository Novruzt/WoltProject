using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wolt.BLL.DTOs.RestaurantDTOs
{
    public record GetAllCategoriesDTO
    {
        public string Name { get; set; }
        public int Foods { get; set; }
    }
}
