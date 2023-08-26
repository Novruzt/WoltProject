using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wolt.Entities.Entities.UserEntities;

namespace Wolt.BLL.DTOs.UserProfileDTOs
{
    public record AddUserAdressDTO
    {
        [SwaggerSchema(ReadOnly = true)]
        public int UserId { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Location { get; set; }
    }
}
