using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wolt.Entities.Entities.RestaurantEntities;
using Wolt.Entities.Entities.UserEntities;

namespace Wolt.BLL.DTOs.UserInteractDTOs
{
    public record GetUserReviewDTO
    {
        public string UserName { get; set; }
        public double Score { get; set; }
        public string? Description { get; set; }
        public string ProductName { get; set; }
        public string CreationTime { get; set; }
    }
}
