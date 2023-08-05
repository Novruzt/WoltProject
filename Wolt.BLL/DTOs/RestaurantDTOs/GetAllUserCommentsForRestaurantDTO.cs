using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wolt.BLL.DTOs.RestaurantDTOs
{
    public record  GetAllUserCommentsForRestaurantDTO
    {
        public string Details { get; set; }
        public string UserName { get; set; }
        public DateTime CommentDate { get; set; }
    }
}
