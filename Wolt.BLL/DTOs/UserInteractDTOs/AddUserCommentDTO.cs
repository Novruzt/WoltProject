﻿using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Wolt.Entities.Entities.RestaurantEntities;
using Wolt.Entities.Entities.UserEntities;


namespace Wolt.BLL.DTOs.UserInteractDTOs
{
    public record AddUserCommentDTO
    {
       [SwaggerSchema(ReadOnly = true)]
        public int UserId { get; set; }
        public string Details { get; set; }
        public int RestaurantId { get; set; }
    }
}
