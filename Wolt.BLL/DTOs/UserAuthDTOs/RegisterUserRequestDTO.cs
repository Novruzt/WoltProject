﻿using Microsoft.AspNetCore.Http;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wolt.BLL.DTOs.UserAuthDTOs
{
    public record RegisterUserRequestDTO
    {
        [Required]
        public string Name { get; set;}
        public string Surname { get; set;}
        [Required]
        [EmailAddress]
        [RegularExpression(@"^(string@example\.com|[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,})$", ErrorMessage = "Invalid Email adress")]
        public string Email { get; set;} = null;
        [Required]
        public string Password { get; set;} 
        public string? Phone { get; set; }
        public IFormFile? ProfilePic { get; set;}
        [SwaggerSchema(ReadOnly = true)]
        public string? ProfilePicture { get; set;}
    }
}
