using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wolt.Entities.Entities.RestaurantEntities;
using Wolt.Entities.Entities.UserEntities;

namespace Wolt.BLL.DTOs.UserInteractDTOs
{
    public record GetAllUserReviewsDTO
    {
        public string UserName { get; set; }
        public string ProductName { get; set; }
    }
}
