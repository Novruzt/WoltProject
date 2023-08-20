using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wolt.BLL.DTOs.UserProfileDTOs
{
    public record AddUserPaymentDTO
    {
        [SwaggerSchema(ReadOnly = true)]
        public int UserId { get; set; }
        public string CardNumber { get; set; }
        public string CVV { get; set; }
        public string ExpireTime { get; set; }
    }
}
