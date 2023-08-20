using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wolt.BLL.DTOs.UserProfileDTOs
{
    public record UserFavoriteRestaurantDTO
    {
        public string Name { get; set; }
        public string BaseAddress { get; set; }
        public string Phone { get; set; }
        public string Description { get; set; }
        public int Categories { get; set; }
    }
}
