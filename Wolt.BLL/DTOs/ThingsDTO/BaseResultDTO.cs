using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wolt.BLL.Enums;

namespace Wolt.BLL.DTOs.ThingsDTO
{
    public record BaseResultDTO
    {
       public RequestStatus Status { get; set; }
       public string Message { get; set; }
    }
}
