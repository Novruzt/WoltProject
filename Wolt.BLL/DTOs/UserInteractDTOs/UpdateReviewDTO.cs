using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wolt.BLL.DTOs.UserInteractDTOs
{
    public class UpdateReviewDTO
    {
        public int revId { get; set; }
        public double? Score { get; set; }
        public string? Description { get; set; }

    }
}
