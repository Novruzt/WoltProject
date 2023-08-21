using Microsoft.AspNetCore.Http;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wolt.BLL.DTOs.UserAuthDTOs
{
    public record ChangeProfilePictureDTO
    {
        [SwaggerSchema(ReadOnly = true)]
        public int UserId { get; set; }
        public IFormFile? ProfilePic { get; set; }
    }
}
