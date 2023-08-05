using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wolt.Entities.Entities.UserEntities;
using Wolt.Entities.Entities.WoltEntities;

namespace Wolt.BLL.DTOs.UserAuthDTOs
{
    public record GetUserProfileDTO
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string? ProfilePicture { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public string Phone { get; set; }
      
    }
}
