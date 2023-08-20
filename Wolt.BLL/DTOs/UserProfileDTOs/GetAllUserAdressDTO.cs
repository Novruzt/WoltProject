using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wolt.Entities.Entities.UserEntities;

namespace Wolt.BLL.DTOs.UserProfileDTOs
{
    public record GetAllUserAdressDTO
    {
        public string Country { get; set; }
        public string City { get; set; }
        public string Location { get; set; }
    }
}
