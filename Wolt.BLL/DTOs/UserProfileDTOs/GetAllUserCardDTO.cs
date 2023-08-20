using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wolt.Entities.Entities.UserEntities;

namespace Wolt.BLL.DTOs.UserProfileDTOs
{
    public record GetAllUserCardDTO
    {
        public string CardNumber { get; set; }
        public string CVV { get; set; }
        public string ExpireTime { get; set; }
    }
}
