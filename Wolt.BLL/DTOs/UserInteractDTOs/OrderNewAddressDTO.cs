using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wolt.BLL.DTOs.UserInteractDTOs
{
    public record OrderNewAddressDTO
    {
        public string Country { get; set; } 
        public string City { get; set; } 
        public string Location { get; set; } 
    }
}
