using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wolt.Entities.Entities.UserEntities;

namespace Wolt.BLL.DTOs.Others
{
    public record UserCommentDTO
    {
        public int UserId { get; set; }
        public int RestaurantId { get; set; }
    }
}
