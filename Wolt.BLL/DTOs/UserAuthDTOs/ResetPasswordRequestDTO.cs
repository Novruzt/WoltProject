using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wolt.BLL.DTOs.UserAuthDTOs
{
    public class ResetPasswordRequestDTO
    {
        public string Password { get; set; }
        public string newPassword { get; set; }
        public string PassAgain { get; set; }
    }
}
