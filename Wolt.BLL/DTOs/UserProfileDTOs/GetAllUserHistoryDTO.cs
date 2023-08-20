using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wolt.BLL.DTOs.UserProfileDTOs
{
    public record GetAllUserHistoryDTO
    {
        public string OrderTime { get; set; }
        public string OrderStatus { get; set; }
        public double OrderTotalAmount { get; set; }
        public string OrderAddress { get; set; }
        public string? Description { get; set; }
      
    }
}
