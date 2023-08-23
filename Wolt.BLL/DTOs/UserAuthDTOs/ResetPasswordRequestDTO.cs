using Microsoft.Identity.Client;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wolt.BLL.DTOs.UserAuthDTOs
{
    public class ResetPasswordRequestDTO
    {
        [SwaggerSchema(ReadOnly = true)]
        public int UserId { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string newPassword { get; set; }
        [Required]
        public string PassAgain { get; set; }
    }
}
