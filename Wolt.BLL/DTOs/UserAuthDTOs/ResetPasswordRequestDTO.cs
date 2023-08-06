using Microsoft.Identity.Client;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wolt.BLL.DTOs.UserAuthDTOs
{
    public class ResetPasswordRequestDTO
    {
        [SwaggerSchema(ReadOnly = true)]
        public int UserId { get; set; }
        public string Password { get; set; }
        public string newPassword { get; set; }
        public string PassAgain { get; set; }
    }
}
