using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wolt.BLL.DTOs.UserInteractDTOs
{
    public record GetUserCommentDTO
    {
        public string UserName { get; set; }
        public string RestaurantName { get; set; }
        public string Details { get; set; }
    }
}
