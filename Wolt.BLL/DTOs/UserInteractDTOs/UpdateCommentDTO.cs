using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wolt.BLL.DTOs.UserInteractDTOs
{
    public record UpdateCommentDTO
    {
        public int commId { get; set; }
        public string? desc { get; set; }
    }
}
