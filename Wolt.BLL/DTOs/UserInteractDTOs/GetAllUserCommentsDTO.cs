using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wolt.BLL.DTOs.UserInteractDTOs
{
    public record GetAllUserCommentsDTO
    {
        public string UserName { get; set; }
        public string RestaurantName { get; set; }
    }
}
