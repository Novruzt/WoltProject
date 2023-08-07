using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wolt.BLL.DTOs.UserInteractDTOs
{
    public record ReturnOrderDTO
    {
        public int OrderId { get; set; }
        public string? Reason { get; set; }
    }
}
