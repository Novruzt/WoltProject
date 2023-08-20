using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wolt.BLL.DTOs.UserProfileDTOs
{
    public record DeleteUserCardDTO
    {
        public int CardID { get; set; }
        public string CVV { get; set; }
        public string ExpireDate { get; set; }
    }
}
